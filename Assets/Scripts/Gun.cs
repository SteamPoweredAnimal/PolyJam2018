using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Missile missileA;
    public Missile missileB;
    public float missileSpeed;

    public void Fire(Missile missile, Vector2 direction)
    {
        Missile _missile = Instantiate(missile);
        _missile.transform.position = transform.position;
        _missile.velocity = direction * missileSpeed;
    }
}
