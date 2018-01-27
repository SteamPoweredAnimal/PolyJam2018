using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Missile missileA;
    public Missile missileB;
    public float missileSpeed;
    private GameObject Owner;
    float timer = 0f;
    float powerupLifespan = 0f;

    public bool normalGun = true;
    public bool machineGun = false;

    public enum GunType
    {
        Normal = 0,
        Machine = 1
    }

    private void Start()
    {
        Owner = transform.parent.gameObject;
    }

    public void Fire(Missile missile, Vector2 direction)
    {
        Missile _missile = Instantiate(missile);
        _missile.OwnerName = Owner.name;
        _missile.transform.position = transform.position;
        _missile.velocity = direction * missileSpeed;
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
    }

}
