using UnityEngine;

public class InputController : MonoBehaviour
{
    public string MoveXAxisName;
    public string MoveYAxisName;
    public string LookXAxisName;
    public string LookYAxisName;
    public string Button0Name;
    public string Button1Name;
    
    public float GetXMoveAxis() => Input.GetAxis(MoveXAxisName);
    public float GetYMoveAxis() => Input.GetAxis(MoveYAxisName);
    public float GetXLookAxis() => Input.GetAxis(LookXAxisName);
    public float GetYLookAxis() => Input.GetAxis(LookYAxisName);
    public bool Get0ShootButton() => Input.GetButton(Button0Name);
    public bool Get1ShootButton() => Input.GetButton(Button1Name);
}