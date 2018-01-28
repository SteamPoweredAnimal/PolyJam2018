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

            Material newMaterial;
            Sprite newSprite;
            switch (newType)
            {
                case Missile.MissileType.False:
                    newMaterial = missile.falseMaterial;
                    GetComponent<AudioSource>().clip = ChangeSound1;

                    break;
                case Missile.MissileType.True:
                    newMaterial = missile.trueMaterial;
                    GetComponent<AudioSource>().clip = ChangeSound2;
                    break;
                default:
                    newMaterial = missile.spriteRenderer.material;
                    break;
            }
            GetComponent<AudioSource>().Play();
            missile.type = newType;
            missile.spriteRenderer.material = newMaterial;
        }
    }
}
