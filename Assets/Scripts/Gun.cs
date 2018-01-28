﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int bullets = 6;
    public AmmoDisplay ammoDisplay;

    public Image weaponImage;
    public Sprite[] weaponSprites;
   
    public bool normalGun = true;
    public bool shotGun = false;
    public bool grenadeGun = false;


    private AudioSource Audio;
    public AudioClip SoundReloadSound;

    public enum GunType
    {
        Normal = 0,
        Machine = 1,
        Grenade = 3
    }

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        Owner = transform.parent.gameObject;
        cooldownTimer = cooldown;
        ammoDisplay.Refresh(this);
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
            ammoDisplay.Refresh(this);
            if (bullets <= 0)
            {
                Reload();
            }
        }
    }

    public void ShotgunFire(Missile missile, Vector2 direction)
    {
        if (canShoot)
        {
            for (int i = 0; i < 6; i++)
            {
                Missile _missile = Instantiate(missile);
                _missile.justSpawned = true;
                _missile.OwnerName = Owner.name;
                float angle = -15f + 6f * i;
                Vector2 newDirection = new Vector2(-Mathf.Sin(angle), -Mathf.Cos(angle));
                _missile.transform.position = transform.position;
                _missile.velocity = newDirection * missileSpeed;
                bullets--;
                ammoDisplay.Refresh(this);
                if (bullets <= 0)
                {
                    
                    Reload();
                }
            }
        }
    }

    public void PowerUp(float lifespan, GunType type)
    {
        normalGun = false;
        shotGun = false;
        grenadeGun = false;
        powerupLifespan = lifespan;
        switch (type)
        {
            case GunType.Machine:
                shotGun = true;
                weaponImage.sprite = weaponSprites[1];
                break;
            case GunType.Grenade:
                grenadeGun = true;
                weaponImage.sprite = weaponSprites[2];
                break;
            default:
                normalGun = true;
                weaponImage.sprite = weaponSprites[0];
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
                shotGun = false;
                timer = 0f;
                weaponImage.sprite = weaponSprites[0];
            }
            timer += Time.deltaTime;
        }

        if (canShoot && bullets != ammoDisplay.activeBullets) ammoDisplay.Refresh(this) ;
        canShoot = cooldownTimer >= cooldown;
        cooldownTimer += Time.deltaTime;
    }

    void Reload()
    {
        Audio.Play(); //Play Reload sound
        canShoot = false;
        bullets = 6;
        cooldownTimer = 0f;        
    }

}
