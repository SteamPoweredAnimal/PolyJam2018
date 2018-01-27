using UnityEngine;

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
    float dashCooldown = 10f;


    private new Rigidbody2D rigidbody2D;

	private void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
        if (!doingDash)
        {
            var translation = new Vector2(InputController.GetXMoveAxis(), InputController.GetYMoveAxis()) * Speed;
            rigidbody2D.velocity = translation;
    }

        if (Input.GetKeyDown(KeyCode.Space))//InputController.GetDashButtonDown())
        {
            doingDash = true;
            dashTimer = 0f;
            rigidbody2D.velocity = rigidbody2D.velocity* 5f;
        }


var look = new Vector3(0, 0, Mathf.Atan2(InputController.GetXLookAxis(), -InputController.GetYLookAxis()) * Mathf.Rad2Deg);
		transform.rotation = Quaternion.Euler(look);
		
		if (InputController.Get0ShootButtonDown())
		{
			if (gun.normalGun) gun.Fire(gun.missileA[0], GetGunDirection());
            if (gun.shotGun) gun.ShotgunFire(gun.missileA[0], GetGunDirection());
		} else if (InputController.Get1ShootButtonDown()) //avoid shooting two different missiles at once
		{
            if (gun.normalGun) gun.Fire(gun.missileB[0], GetGunDirection());
            if (gun.shotGun) gun.ShotgunFire(gun.missileB[0], GetGunDirection());
        }
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
}
