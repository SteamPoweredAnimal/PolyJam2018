using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class HealthBar : MonoBehaviour
{
    public GameObject Zero, One;
    public List<char> CurrentHP = new List<char>();
    public Transform Parent;
    public Scoreboard Scoreboard;
    public Vector3 SpawnPoint;
    // public AudioClip HurtSound;
    // public AudioClip DeathSound;
    // private AudioSource ASource;
   // private PlayerControler Player;



    private List<GameObject> currentHPBar = new List<GameObject>();
    private bool[] isActive;
    
    private Vector3 WPizduDaleko = new Vector3(-10000, -10000, -10000);

    public void Start()
    {
        currentHPBar = new List<GameObject>();
       
        SetUpHpBar();

        //ASource = GetComponent<AudioSource>();
    }

    public void TakeDamage(char fromWhat, string missile)
    {
        if (fromWhat == CurrentHP.First())
        {
            CurrentHP.Remove(CurrentHP.First());
            GameObject healthObject = currentHPBar.First();
            currentHPBar.Remove(currentHPBar.First());
            Destroy(healthObject);
            Parent.GetComponent<PlayerControler>().PlayBitDown();
        } else
        {
            CurrentHP.Insert(0, fromWhat);
            GameObject healthObject = Instantiate(fromWhat == '0'? Zero : One, transform);
            currentHPBar.Insert(0, healthObject);
            healthObject.transform.SetAsFirstSibling();
            Parent.GetComponent<PlayerControler>().PlayBitUp();
        }

        if (CurrentHP.Count <= 0 || CurrentHP.Count >= 8)
        {
            if (missile == Parent.name) Scoreboard.RemovePoint(missile);
            else Scoreboard.AddPoint(missile);
            Die();
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
        return Convert.ToString(Random.Range(0, 16), 2).PadLeft(4, '0');
    }

    private void SetUpHpBar()
    {
        CurrentHP = GenerateNewHP().ToCharArray().ToList();
        
        foreach (var o in currentHPBar)
        {
            Destroy(o);
        }

        currentHPBar = new List<GameObject>();
        isActive = Enumerable.Repeat(true, CurrentHP.Count).ToArray();

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
        //ASource.clip = DeathSound;
        //ASource.Play();
        Parent.GetComponent<PlayerControler>().PlayDeathSound();
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
