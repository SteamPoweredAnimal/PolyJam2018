using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashShadow : MonoBehaviour
{

    float lifespan = .2f;
    float timer = 0f;
    public Sprite sprite;
    SpriteRenderer spriteRenderer;
    // Use this for initialization

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Color color = spriteRenderer.color;
        color.a = 1 - 1 * (timer / lifespan);
        Debug.Log("Color alpha: " + color.a);
        spriteRenderer.color = color;
        Debug.Log("Renderer alpha: " + spriteRenderer.color.a);
        if (timer >= lifespan) Destroy(gameObject);
    }
}