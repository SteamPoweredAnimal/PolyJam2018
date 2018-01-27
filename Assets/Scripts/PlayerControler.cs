using UnityEngine;

public class PlayerControler : MonoBehaviour
{
	public InputController InputController;
	public float Speed;
    public Gun gun;
	public HealthBar healthBar;

	private Rigidbody2D rigidbody2D;

	private void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		var translation = new Vector2(InputController.GetXMoveAxis(), InputController.GetYMoveAxis()) * Speed;
		rigidbody2D.velocity = translation;
       
		var look = new Vector3(0, 0, Mathf.Atan2(InputController.GetXLookAxis(), -InputController.GetYLookAxis()) * Mathf.Rad2Deg);
		transform.rotation = Quaternion.Euler(look);
		
		if (InputController.Get0ShootButton())
		{
			gun.Fire(gun.missileA, GetGunDirection());
		} else if (InputController.Get1ShootButton()) //avoid shooting two different missiles at once
		{
			gun.Fire(gun.missileB, GetGunDirection());
		}
	}

    private Vector2 GetGunDirection()
    {
        Vector2 gun_direction = gun.transform.position - transform.position;
        return gun_direction / gun_direction.magnitude;
    }
}
