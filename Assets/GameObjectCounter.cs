using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameObjectCounter : MonoBehaviour {

    float counter = 0f;	
	// Update is called once per frame
	void Update () {
        counter = FindObjectsOfType<GameObject>().Length;
        if (counter > 40)
        {
            UnityEditor.EditorApplication.isPaused = true;
        }
	}
}
