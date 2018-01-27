﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public Vector2 velocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Time.deltaTime * new Vector3(velocity.x, velocity.y, 0f);
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        Debug.Log("Collision detected");
        Destroy(gameObject);

	    var player = col.gameObject.GetComponent<PlayerControler>();
	    if (player != null)
	    {
		    player.HealthBar.TakeDamage('0');
	    }
    }
}
