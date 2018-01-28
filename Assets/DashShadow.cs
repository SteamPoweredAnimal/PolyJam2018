using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashShadow : MonoBehaviour {

    float lifespan = 1f;
    float timer = 0f;
    SpriteRenderer spriteRenderer;
	// Use this for initialization

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = GetComponentInParent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        Color color = spriteRenderer.color;
        color.a = 255 - 255 * (timer / lifespan);
        spriteRenderer.color = color;
        if (timer >= lifespan) Destroy(gameObject);
	}
}