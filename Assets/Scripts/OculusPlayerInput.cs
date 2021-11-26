using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusPlayerInput : PlayerInput
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
        return Input.GetMouseButton(0);
    }

    public bool GetFlightDown()
    {
        return Input.GetMouseButtonDown(0);
    }
}
