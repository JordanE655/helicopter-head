using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusPlayerInput : PlayerInput
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    
    public Quaternion rot;
    public Vector3 rotty;

    public GameObject camContainer;

    public void InitializeInput(GameObject gam)
    {
        gyroEnabled = EnableGyro(gam);
    }

    private bool EnableGyro(GameObject gam)
    {
        camContainer = new GameObject("Cam Container");
        camContainer.transform.position = gam.transform.position;
        gam.transform.SetParent(camContainer.transform);
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            rot = new Quaternion(0, 0, 1, 0);
            camContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);

            return true;
        }
        return false;
    }

    public void RotateHead(GameObject head)
    {
        head.transform.localRotation = gyro.attitude;
    }



    public float GetAxisX()
    {
        //replace all of these with objects?
        return Input.acceleration.x;
    }
    public float GetAxisY()
    {
        Debug.Log(-Input.acceleration.y);
        return (-Input.acceleration.y - 1f);
    }

    public bool GetFlightHeld()
    {
        return Input.GetMouseButton(0);
    }

    public bool GetFlightDown()
    {
        return Input.GetMouseButtonDown(0);
    }
    public bool GetFlightUp()
    {
        return Input.GetMouseButtonUp(0);
    }

    public bool IsMobile()
    {
        return true;
    }
}
