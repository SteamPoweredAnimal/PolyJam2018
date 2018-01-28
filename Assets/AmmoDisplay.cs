using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour {

    public Image[] bulletImages;
    public int activeBullets = 6;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Refresh(Gun gun)
    {
        activeBullets = 0;
        int j;
        for (int i = 5; i >= 0; i--) {
            j = 5 - i;
            Color color = bulletImages[i].color;
            if (i < gun.bullets)
            {
                color.a = 1f;
                activeBullets++;
            } else
            {
                color.a = .1f;
            }
            bulletImages[j].color = color;
        }
    }
}
