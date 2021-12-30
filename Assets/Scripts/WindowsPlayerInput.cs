using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsPlayerInput : PlayerInput
{

    public void InitializeInput(GameObject gam)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void RotateHead(GameObject head )
    {

    }

    public bool GetPause()
    {
        if (Input.GetButtonDown("Submit"))
        {
            Debug.LogError(Input.GetButtonDown("Submit"));
        }
        
        return Input.GetButtonDown("Submit");
    }

    public void SetCursor()
    {
        Cursor.visible = !Cursor.visible;
        if (Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.None;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

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
        return Input.GetButton("Jump") || Input.GetMouseButton(0);
    }

    public bool GetFlightDown()
    {
        return Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0);
    }

    public bool GetFlightUp()
    {
        return Input.GetButtonUp("Jump") || Input.GetMouseButtonUp(0);
    }

    public bool IsMobile()
    {
        return false;
    }
}
