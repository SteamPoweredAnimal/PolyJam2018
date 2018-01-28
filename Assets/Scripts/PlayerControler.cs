using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
    public InputController InputController;
    public float Speed;
    public Gun gun;
    public HealthBar HealthBar;
    public int Score;
    public AudioClip PowerUpSound;
    public AudioClip HealthDownSound;
    public AudioClip HealthUpSound;
    public AudioClip DeathSound;
    bool doingDash = false;
    float dashTimer = 0f;
    float dashCooldown = 2.2f;
    public Vector3 previousLook;
    public bool allowFire;

    public DashShadow shadow;

    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        previousLook = new Vector3(0, 0, 0);
        allowFire = true;
        dashTimer = dashCooldown;

    }

    private void Update()
    {
        if (!doingDash)
        {
            var translation = new Vector2(InputController.GetXMoveAxis(), InputController.GetYMoveAxis()) * Speed;
            rigidbody2D.velocity = translation;

        }
        if (InputController.GetDashButtonDown() && dashTimer >= dashCooldown)
        {
            doingDash = true;
            rigidbody2D.velocity = rigidbody2D.velocity * 10f;
            dashTimer = 0f;
            StartCoroutine("SpawnShadow");
        }
        dashTimer += Time.deltaTime;
        if (doingDash && dashTimer >= 0.1f)
        {
            rigidbody2D.velocity = Vector3.zero;
            //if (dashTimer >= 0.5f)
            //{
            doingDash = false;
            StopCoroutine("SpawnShadow");
            //}
        }


        var look = new Vector3(0, 0, Mathf.Atan2(InputController.GetXLookAxis(), -InputController.GetYLookAxis()) * Mathf.Rad2Deg);
        Debug.Log(look.magnitude);
        if (new Vector2(InputController.GetXLookAxis(), -InputController.GetYLookAxis()).magnitude > 0.8)
        {
            previousLook = look;
        }
        transform.rotation = Quaternion.Euler(previousLook);

        if (allowFire && InputController.GetShootButton() > 0.2)
        {
            allowFire = false;
            if (gun.normalGun) gun.Fire(gun.missileA[0], GetGunDirection());
            if (gun.shotGun) gun.ShotgunFire(gun.missileA[0], GetGunDirection());
            if (gun.grenadeGun)
            {
                gun.grenadeGun = false;
                gun.normalGun = true;
                gun.Fire(gun.missileA[1], GetGunDirection());
            }
        }
        else if (allowFire && InputController.GetShootButton() < -0.2)
        {
            allowFire = false;
            if (gun.normalGun) gun.Fire(gun.missileB[0], GetGunDirection());
            if (gun.shotGun) gun.ShotgunFire(gun.missileB[0], GetGunDirection());
            if (gun.grenadeGun)
            {
                gun.grenadeGun = false;
                gun.normalGun = true;
                gun.Fire(gun.missileB[1], GetGunDirection());
            }
        }
        else if (Mathf.Abs(InputController.GetShootButton()) < 0.2)
            allowFire = true;
    }

    private Vector2 GetGunDirection()
    {
        Vector2 gun_direction = gun.transform.position - transform.position;
        return gun_direction / gun_direction.magnitude;
    }


    public void PlayBuffSound()
    {
        GetComponent<AudioSource>().clip = PowerUpSound;
        GetComponent<AudioSource>().Play();

    }

    IEnumerator SpawnShadow()
    {
        DashShadow shadowGO = Instantiate(shadow, transform);
        shadowGO.transform.position = transform.position;
        shadowGO.transform.rotation = transform.rotation;

        yield return new WaitForSeconds(0.02f);

    }

    public void PlayBitUp()
    {
        GetComponent<AudioSource>().clip = HealthDownSound;
        GetComponent<AudioSource>().Play();

    }

    public void PlayBitDown()
    {
        GetComponent<AudioSource>().clip = HealthUpSound;
        GetComponent<AudioSource>().Play();

    }

    public void PlayDeathSound()
    {
        GetComponent<AudioSource>().clip = DeathSound;
        GetComponent<AudioSource>().Play();
        
    }
}
