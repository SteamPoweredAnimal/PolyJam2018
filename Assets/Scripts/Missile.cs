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
    public bool justSpawned = false;

    public enum MissileType
    {
        False = 0,
        True = 1,
        Qbit = 2
    }

    public string OwnerName { get; set; }

    // Use this for initialization
    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        //collider.enabled = false;
        GetComponent<AudioSource>().pitch = Random.Range(0.2f, 2.1f);//Change pitch of fire sound
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (timer >= activationTime) justSpawned = false;
        else timer += Time.deltaTime;

        transform.position += Time.deltaTime * new Vector3(velocity.x, velocity.y, 0f);
    }

    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        
        var collider = col.collider;
        Missile colliderMissile = collider.GetComponent<Missile>();

        if (justSpawned && colliderMissile != null) return;

            if (sparkPrefab != null)
        {
            Spark spark = Instantiate(sparkPrefab);
            spark.transform.position = transform.position;
            spark.transform.Translate(new Vector3(velocity.x / velocity.magnitude * spriteRenderer.bounds.size.x / 2, velocity.y / velocity.magnitude * spriteRenderer.bounds.size.y / 2, -0.01f));
        }

        
        var collidedPlayer = collider.GetComponent<PlayerControler>();

        if (collider.CompareTag("MirrorVertical"))
        {
            velocity = new Vector2(-velocity.x, velocity.y);
            return;
        }
        if (collider.CompareTag("MirrorHorizontal"))
        {
            velocity = new Vector2(velocity.x, -velocity.y);
            return;
        }
        
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

    protected virtual void ManageCollision(Missile missile1, Missile missile2)
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
