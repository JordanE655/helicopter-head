using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : ScriptableObject
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public float charge = 0f;
    public float wind = 1.5f;
    bool unreleased;

    public Vector3 capturePoint;
    public GameObject captureObject;

    // Using the player's input, changes the tilt of the head (and therefore the camera)
    // Also sets yaw and pitch
    public void HeadHandling(GameObject heliHead, PlayerInput inputFloats)
    {
        if (inputFloats.IsMobile())
        {
            inputFloats.RotateHead(heliHead);
        }
        else
        {
            yaw += speedH * inputFloats.GetAxisX();
            yaw = yaw % 360f;
            pitch += speedV * inputFloats.GetAxisY();

            heliHead.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }

        if (inputFloats.GetPause())
        {
            inputFloats.SetCursor();
        }
        
    }

    // Using the player's input, changes the speed and flight of the character
    public float FlightHandling(Vector3 direction, Rigidbody heliBod, PlayerInput playerInput)
    {
        direction = Vector3.Normalize(direction);
        if (playerInput.GetFlightDown())
        {
            if (wind >= .5f)
            {
                charge = 0f;
            }
            heliBod.useGravity = false;
            heliBod.drag = 3f;
            unreleased = true;

            //
        }
        if (playerInput.GetFlightHeld())
        {
            if (unreleased)
            {
                if (wind >= Time.deltaTime)
                {
                    charge += Time.deltaTime;
                } else
                {
                    charge += wind;
                }
                
            }
            
            
        }
        if (charge >= wind || playerInput.GetFlightUp())
        {
            heliBod.useGravity = true;
            heliBod.drag = 0f;
            unreleased = false;
            wind -= charge;
            // 1.5 is max charge on full wind (0-100?)
            // maybe charge happpens in chunks of .3
            // 5 units of wind?
            float returnable = .3f * charge;
            charge = 0;
            return returnable;
        }
        return 0f;
    }
}
