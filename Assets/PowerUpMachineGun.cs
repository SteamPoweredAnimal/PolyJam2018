using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMachineGun : PowerUp {

    protected override void Activate(PlayerControler player)
    {
        base.Activate(player);
        player.useGun = false;
    }

}
