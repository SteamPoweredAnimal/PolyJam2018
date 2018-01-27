using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMachineGun : PowerUp {

    float lifespan = 10f;

    protected override void Activate(PlayerControler player)
    {
        base.Activate(player);
        player.gun.PowerUp(lifespan, Gun.GunType.Machine);
    }

}
