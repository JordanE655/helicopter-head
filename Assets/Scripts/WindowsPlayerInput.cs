using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsPlayerInput : PlayerInput
{

    public float GetAxisX()
    {
        //replace all of these with objects?
        return Input.GetAxis("Mouse X");
    }
    public float GetAxisY()
    {
        return Input.GetAxis("Mouse Y");
    }

    public bool GetFlightHeld()
    {
        return Input.GetButton("Jump");
    }

    public bool GetFlightDown()
    {
        return Input.GetButtonDown("Jump");
    }
}
