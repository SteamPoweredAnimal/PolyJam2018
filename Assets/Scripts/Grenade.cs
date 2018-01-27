using System.Collections;
using UnityEngine;

public class Grenade : Missile
{
    public Missile MissileZero, MissileOne;
    
    protected override void Start()
    {
        base.Start();

        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(2);
        
        Destroy(gameObject);

        var amount = Random.Range(7, 12);

        for (int i = 0; i < amount; i++)
        {
            var angle = Random.insideUnitCircle;

            if (type == MissileType.False)
            {
                var missile = Instantiate(MissileZero, transform.position, Quaternion.identity);
                missile.GetComponent<Missile>().velocity = angle;
            }
        }
    }
}
