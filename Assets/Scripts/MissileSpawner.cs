using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public Missile missileTrue;
    public Missile missileFalse;
    public void ManageMissileCollision (Collision2D collision)
    {
        Missile missile1 = collision.collider.gameObject.GetComponent<Missile>();
        Missile missile2 = collision.otherCollider.gameObject.GetComponent<Missile>();

        bool sameType = missile1.type == missile2.type;

        float speed = (missile1.velocity.magnitude + missile2.velocity.magnitude) / 2f;
        Vector2 newVelocity = Random.insideUnitCircle * speed;
        var newMissilePrefab = sameType ? missileTrue : missileFalse;
        Missile newMissile = Instantiate(newMissilePrefab); 
        newMissile.transform.position = collision.transform.position;
        newMissile.velocity = newVelocity;

        Destroy(missile1.gameObject);
        Destroy(missile2.gameObject);
    }
}