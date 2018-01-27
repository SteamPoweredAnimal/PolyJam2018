using UnityEngine;

public class PlayerControler : MonoBehaviour
{
	public InputController InputController;
	public float Speed;

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
	}
}
