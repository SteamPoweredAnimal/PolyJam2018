using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGate : MonoBehaviour
{
    public AudioClip ChangeSound1;
    public AudioClip ChangeSound2;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Missile missile = collider.GetComponent<Missile>();

        if (missile != null)
        {
            
            Missile.MissileType newType = missile.type == Missile.MissileType.False ? Missile.MissileType.True : Missile.MissileType.False;

            Sprite newSprite;
            switch (newType)
            {
                case Missile.MissileType.False:
                    newSprite = missile.falseSprite;
                    GetComponent<AudioSource>().clip = ChangeSound1;

                    break;
                case Missile.MissileType.True:
                    newSprite = missile.trueSprite;
                    GetComponent<AudioSource>().clip = ChangeSound2;
                    break;
                default:
                    newSprite = missile.spriteRenderer.sprite;
                    break;
            }
            GetComponent<AudioSource>().Play();
            missile.type = newType;
            missile.spriteRenderer.sprite = newSprite;
        }
    }
}
