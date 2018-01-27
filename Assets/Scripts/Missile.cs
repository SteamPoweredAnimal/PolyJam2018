using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public Vector2 velocity;
    public MissileType type;
    float activationTime = .1f;
    float timer = 0f;
    [HideInInspector]
    public BoxCollider2D collider;
    SpriteRenderer spriteRenderer;

    public enum MissileType
    {
        False = 0,
        True = 1,
        Qbit = 2
    }

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= activationTime) collider.enabled = true;
        else timer += Time.deltaTime;

        transform.position += Time.deltaTime * new Vector3(velocity.x, velocity.y, 0f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var collider = col.collider;

        Missile colliderMissile = collider.GetComponent<Missile>();

        if (colliderMissile != null) ManageCollision(this, colliderMissile);
        else Destroy(gameObject);
    }

    void ManageCollision(Missile missile1, Missile missile2)
    {
        bool sameType = missile1.type == missile2.type;

        float speed = (missile1.velocity.magnitude + missile2.velocity.magnitude) / 2f;
        Vector2 newVelocity = Random.onUnitSphere * speed;
        MissileType newType = sameType ? MissileType.True : MissileType.False;

        missile1.type = newType;
        missile1.velocity = newVelocity;
        missile1.collider.enabled = false;
        missile1.timer = 0f;

        missile2.type = newType;
        missile2.velocity = -newVelocity;
        missile2.collider.enabled = false;
        missile2.timer = 0f;

    }
}
