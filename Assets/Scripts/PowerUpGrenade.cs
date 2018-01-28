public class PowerUpGrenade : PowerUp
{
    float lifespan = 120f;

    protected override void Activate(PlayerControler player)
    {
        base.Activate(player);
        player.gun.PowerUp(lifespan, Gun.GunType.Grenade);
    }
}
