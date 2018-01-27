using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private Dictionary<string, Text> scores;
    private Dictionary<string, int> points;
    
    private void Start()
    {
        scores = new Dictionary<string, Text>();
        points = new Dictionary<string, int>();
        
        foreach (Transform child in transform)
        {
            var name = child.GetChild(0).GetComponent<Text>().text;
            var text = child.GetChild(1).GetComponent<Text>();
            
            scores.Add(name, text);
            points.Add(name, 0);
        }
    }

    public void RemovePoint(string missile)
    {
        scores[missile].text = (--points[missile]).ToString();
    }

    public void AddPoint(string missile)
    {
        scores[missile].text = (++points[missile]).ToString();
    }
}
