using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private Text scores;
    private int points;
    
    private void Start()
    {      
            var text = transform.Find("Stats").Find("Row1").Find("Score").GetComponent<Text>();

            scores = text;
            points = 0;


        Debug.Log("name: " + name);
    }

    public void RemovePoint(string missile)
    {
        scores.text = (--points).ToString();
    }

    public void AddPoint()
    {
        scores.text = "Score: " + (++points).ToString();
    }
}
