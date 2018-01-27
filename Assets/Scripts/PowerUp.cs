using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerControler player = collider.gameObject.GetComponent<PlayerControler>();
        if (player != null)
        {

            player.PlayBuffSound();
            Activate(player);
            Destroy(gameObject);
        }
    }

    protected virtual void Activate(PlayerControler player)
    {
        Debug.Log("Power up");
    }
}
