using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    public float lifeSpan;
    float timer = 0;

    void Update()
    {
        if (timer >= lifeSpan) Destroy(gameObject);
        timer += Time.deltaTime;
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Missile>() != null) Destroy(collider.gameObject);
    }

}
