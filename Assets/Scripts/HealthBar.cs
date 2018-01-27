using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealthBar : MonoBehaviour
{
    public GameObject Zero, One;
    public string CurrentHP;
    public Transform Parent;
    public Scoreboard Scoreboard;
    public Vector3 SpawnPoint;
    
    private GameObject[] currentHPBar;
    private bool[] isActive;
    
    private Vector3 WPizduDaleko = new Vector3(-10000, -10000, -10000);

    public void Start()
    {
        currentHPBar = new GameObject[] { };

        SetUpHpBar();
    }

    public void TakeDamage(char fromWhat, string missile)
    {
        var i = 0;
        while (!isActive[i] && i < isActive.Length)
        {
            i++;
        }

        if (fromWhat == CurrentHP[i])
        {
            currentHPBar[i].SetActive(false);
            isActive[i] = false;
            if (i >= isActive.Length - 1)
            {
                Die();
                Score(missile);
            }
        }
        else
        {
            for (var j = 0; j < i; j++)
            {
                currentHPBar[j].SetActive(true);
                isActive[j] = true;
            }
        }
    }

    private void Score(string missile)
    {
        if (Parent.name == missile)
        {
            Scoreboard.RemovePoint(missile);
        }
        else
        {
            Scoreboard.AddPoint(missile);
        }
    }
    
    private static string GenerateNewHP()
    {
        return Convert.ToString(Random.Range(1, 31), 2).PadLeft(5, '0');
    }

    private void SetUpHpBar()
    {
        CurrentHP = GenerateNewHP();
        
        foreach (var o in currentHPBar)
        {
            Destroy(o);
        }

        currentHPBar = new GameObject[CurrentHP.Length];
        isActive = Enumerable.Repeat(true, CurrentHP.Length).ToArray();

        for (var i = 0; i < CurrentHP.Length; i++)
        {
            currentHPBar[i] = Instantiate(CurrentHP[i] == '0' ? Zero : One, transform);
        }
    }

    private void Update()
    {
        var parentPos = Camera.main.WorldToScreenPoint(Parent.position);
        transform.position = parentPos;
    }

    private void Die()
    {
        Parent.position = WPizduDaleko;
        Parent.gameObject.SetActive(false);
        SetUpHpBar();
        StartCoroutine(RespawnAfter5());
    }

    private IEnumerator RespawnAfter5()
    {
        yield return new WaitForSeconds(3);
        Parent.position = SpawnPoint;
        Parent.gameObject.SetActive(true);
        SetUpHpBar();
    }
}
