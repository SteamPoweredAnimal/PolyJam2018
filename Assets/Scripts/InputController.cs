﻿using UnityEngine;

public class InputController : MonoBehaviour
{
    public string MoveXAxisName;
    public string MoveYAxisName;
    public string LookXAxisName;
    public string LookYAxisName;
    public string Button0Name;
    public string Button1Name;

    public float GetXMoveAxis() { return Input.GetAxis(MoveXAxisName); }
    public float GetYMoveAxis() { return Input.GetAxis(MoveYAxisName); }
    public float GetXLookAxis() { return Input.GetAxis(LookXAxisName); }
    public float GetYLookAxis() { return Input.GetAxis(LookYAxisName); }
    public bool Get0ShootButton() { return Input.GetButton(Button0Name); }
    public bool Get1ShootButton() { return Input.GetButton(Button1Name); }
    public bool Get0ShootButtonDown() { return Input.GetButtonDown(Button0Name); }
    public bool Get1ShootButtonDown() { return Input.GetButtonDown(Button1Name); }
}