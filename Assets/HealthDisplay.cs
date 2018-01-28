using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    public Image[] images;
    public Sprite zeroSprite;
    public Sprite oneSprite;
    public Sprite emptySprite;


    public void Refresh(HealthBar healthBar)
    {
        List<char> healthChars = healthBar.CurrentHP;
        Debug.Log("health chars count - 1 = " + (healthChars.Count - 1));
        for (int i = 7; i >= 0 ; i--)
        {
           // Debug.Log(" i = " + i);
            int j = 7 - i;
            if (i < healthChars.Count)
            {
                
                switch (healthChars[healthChars.Count - 1 - i])
                {
                    case '0':
                        images[j].sprite = zeroSprite;
                        break;
                    case '1':
                        images[j].sprite = oneSprite;
                        break;
                    default:
                        images[j].sprite = emptySprite;
                        break;
                }
            } else images[j].sprite = emptySprite;
        }
    }
}
