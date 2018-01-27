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
    public Vector3 previousLook;
    public bool allowFire;


    private new Rigidbody2D rigidbody2D;

	private void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
        previousLook = new Vector3(0, 0, 0);
        allowFire = true;

    }

	private void Update()
	{
		var translation = new Vector2(InputController.GetXMoveAxis(), InputController.GetYMoveAxis()) * Speed;
		rigidbody2D.velocity = translation;
       
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
        }
        else if (allowFire && InputController.GetShootButton() < -0.2)
        {
            allowFire = false;
            if (gun.normalGun) gun.Fire(gun.missileB[0], GetGunDirection());
            if (gun.shotGun) gun.ShotgunFire(gun.missileB[0], GetGunDirection());
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
}
