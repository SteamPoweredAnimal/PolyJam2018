using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class HealthBar : MonoBehaviour
{
    public GameObject Zero, One;
    public List<char> CurrentHP = new List<char>();
    public Transform Parent;
    public Scoreboard Scoreboard;
    public Vector3 SpawnPoint;
    
    private List<GameObject> currentHPBar;
    
    private Vector3 WPizduDaleko = new Vector3(-10000, -10000, -10000);

    public void Start()
    {
        currentHPBar = new List<GameObject>();

        SetUpHpBar();
    }

    public void TakeDamage(char fromWhat, string missile)
    {
        if (fromWhat == CurrentHP.First())
        {
            CurrentHP.Remove(CurrentHP.First());
            GameObject healthObject = currentHPBar.First();
            currentHPBar.Remove(currentHPBar.First());
            Destroy(healthObject);
        } else
        {
            CurrentHP.Insert(0, fromWhat);
            if (fromWhat == '0')
            {
                GameObject healthObject = Instantiate(Zero, transform);
                healthObject.transform.SetAsFirstSibling();
                currentHPBar.Insert(0, healthObject);
            }
            else
            {
                GameObject healthObject = Instantiate(One, transform);
                healthObject.transform.SetAsFirstSibling();
                currentHPBar.Insert(0, healthObject);
            }
        }

        if (CurrentHP.Count <= 0 || CurrentHP.Count >= 8) Die();
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
        return Convert.ToString(Random.Range(0, 16), 2).PadLeft(4, '0');
    }

    private void SetUpHpBar()
    {
        CurrentHP = GenerateNewHP().ToCharArray().ToList<char>();
        
        foreach (var o in currentHPBar)
        {
            Destroy(o);
        }

        currentHPBar = new List<GameObject>();

        for (var i = 0; i < CurrentHP.Count; i++)
        {
            currentHPBar.Add(Instantiate(CurrentHP[i] == '0' ? Zero : One, transform));
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
