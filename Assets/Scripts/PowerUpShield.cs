using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : PowerUp
{

    public GameObject shieldPrefab;

    protected override void Activate(PlayerControler player)
    {
        base.Activate(player);
        if (shieldPrefab != null)
        {
            

            GameObject shieldGO = Instantiate(shieldPrefab, player.transform);
            shieldGO.transform.localPosition = new Vector3(0, 0, 0.01f);
        }
    }

}
