using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Missile missileA;
    public Missile missileB;

    public void Fire(Missile missile)
    {
        Missile _missile = Instantiate(missile);
        _missile.transform.position = transform.position;
    }
}
