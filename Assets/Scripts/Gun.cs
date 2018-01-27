using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Missile[] missileA;
    public Missile[] missileB;
    public float missileSpeed;
    private GameObject Owner;
    float timer = 0f;
    float powerupLifespan = 0f;
    float cooldown = 1f;
    float cooldownTimer;
    bool canShoot = true;
    int bullets = 6;

    public bool normalGun = true;
    public bool machineGun = false;

    public enum GunType
    {
        Normal = 0,
        Machine = 1,
        Grenade = 3
    }

    private void Start()
    {
        Owner = transform.parent.gameObject;
        cooldownTimer = cooldown;
    }

    public void Fire(Missile missile, Vector2 direction)
    {
        if (canShoot)
        {
            Missile _missile = Instantiate(missile);
            _missile.OwnerName = Owner.name;
            _missile.transform.position = transform.position;
            _missile.velocity = direction * missileSpeed;
            bullets--;
            if (bullets <= 0)
            {
                canShoot = false;
                bullets = 6;
                cooldownTimer = 0f;
            }
        }

    }

    public void PowerUp(float lifespan, GunType type)
    {
        normalGun = false;
        powerupLifespan = lifespan;
        switch (type)
        {
            case GunType.Machine:
                machineGun = true;
                break;
            default:
                normalGun = true;
                break;
        }
    }

    private void Update()
    {
        if (!normalGun)
        {
            if (timer >= powerupLifespan)
            {
                normalGun = true;
                machineGun = false;
                timer = 0f;
            }
            timer += Time.deltaTime;
        }

        canShoot = cooldownTimer >= cooldown;
        cooldownTimer += Time.deltaTime;
    }

}
