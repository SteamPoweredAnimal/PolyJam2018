using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Missile : MonoBehaviour
{

    public Vector2 velocity;
    public MissileType type;
    float activationTime = .5f;
    float timer = 0f;
    [HideInInspector]
    public BoxCollider2D collider;
    public SpriteRenderer spriteRenderer;
    public Sprite falseSprite;
    public Sprite trueSprite;
    public Spark sparkPrefab;

    public enum MissileType
    {
        False = 0,
        True = 1,
        Qbit = 2
    }

    public string OwnerName { get; set; }

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        //collider.enabled = false;
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
        if (sparkPrefab != null)
        {
            Spark spark = Instantiate(sparkPrefab);
            spark.transform.position = transform.position;
            spark.transform.Translate(new Vector3(velocity.x / velocity.magnitude * spriteRenderer.bounds.size.x / 2, velocity.y / velocity.magnitude * spriteRenderer.bounds.size.y / 2, -0.01f));
        }

        Missile colliderMissile = collider.GetComponent<Missile>();
        var collidedPlayer = collider.GetComponent<PlayerControler>();

        if (colliderMissile != null)
        {
            if (velocity == -colliderMissile.velocity) return;
            ManageCollision(this, colliderMissile);
        }
        else if (collidedPlayer != null)
        {
            Destroy(gameObject);
            collidedPlayer.HealthBar.TakeDamage(type.ToChar(), OwnerName);
        }
        else Destroy(gameObject);
    }

    void ManageCollision(Missile missile1, Missile missile2)
    {
        bool sameType = missile1.type == missile2.type;

        float speed = (missile1.velocity.magnitude + missile2.velocity.magnitude) / 2f;
        Vector2 newVelocity = Random.insideUnitCircle.normalized * speed;
        MissileType newType = sameType ? MissileType.True : MissileType.False;

        Sprite newSprite;
        switch (newType)
        {
            case MissileType.False:
                newSprite = falseSprite;
                break;
            case MissileType.True:
                newSprite = trueSprite;
                break;
            default:
                newSprite = spriteRenderer.sprite;
                break;
        }

        missile1.type = newType;
        missile1.velocity = newVelocity;
        missile1.timer = 0f;
        missile1.spriteRenderer.sprite = newSprite;

        missile2.type = newType;
        missile2.velocity = -newVelocity;
        missile2.timer = 0f;
        missile2.spriteRenderer.sprite = newSprite;

    }
}
