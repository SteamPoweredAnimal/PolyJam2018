using UnityEngine;

public class PlayerControler : MonoBehaviour
{
	public InputController InputController;
	public float Speed;
    public Gun gun;

	private Rigidbody2D rigidbody2D;

	private void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	private void Update()
	{
		var translation = new Vector2(InputController.GetXMoveAxis(), InputController.GetYMoveAxis()) * Speed;
		rigidbody2D.velocity = translation;
		
		var look = new Vector2(InputController.GetXLookAxis(), InputController.GetYLookAxis());
		transform.rotation = Quaternion.Euler(look);

        if (InputController.Get0ShootButton())
        {
            gun.Fire(gun.missileA, Vector2.right); //TODO : replace Vector2.right with look vector when rotating works
        } else if (InputController.Get1ShootButton()) //avoid shooting two different missiles at once
        {
            gun.Fire(gun.missileB, Vector2.right); //TODO : replace Vector2.right with look vector when rotating works
        }
	}
}
