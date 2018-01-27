using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Missile missileA;
    public Missile missileB;
    public float missileSpeed;
    private GameObject Owner;

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

}
