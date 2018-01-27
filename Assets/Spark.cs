using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour {

    float lifespan = 0.25f;
    float timer = 0f;

	// Update is called once per frame
	void Update () {
		if (timer >= lifespan)
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
	}
}
