using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    public abstract float GetXAxis();
    public abstract float GetYAxis();
    public abstract float Get0ShootButton();
    public abstract float Get1ShootButton();
}