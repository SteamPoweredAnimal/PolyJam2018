using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGate : MonoBehaviour
{

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
                    break;
                case Missile.MissileType.True:
                    newSprite = missile.trueSprite;
                    break;
                default:
                    newSprite = missile.spriteRenderer.sprite;
                    break;
            }
            missile.type = newType;
            missile.spriteRenderer.sprite = newSprite;
        }
    }
}
