using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : ScriptableObject
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float burstSpeed = 0f;

    // Using the player's input, changes the tilt of the head (and therefore the camera)
    // Also sets yaw and pitch
    public void HeadHandling(GameObject heliHead, PlayerInput inputFloats)
    {
        yaw += speedH * inputFloats.GetAxisX();
        yaw = yaw % 360f;
        pitch += speedV * inputFloats.GetAxisY();

        heliHead.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    // Using the player's input, changes the speed and flight of the character
    public void FlightHandling(Rigidbody heliBod, PlayerInput playerInput)
    {

        if (playerInput.GetFlightDown())
        {
            burstSpeed = 5f;
        }
        if (playerInput.GetFlightHeld())
        {
            burstSpeed = (burstSpeed / 2f) + .5f;
            // Advanced Math including checks to the direction you're facing
            // also use time.timescale
            //heliBod.velocity = new Vector3(heliBod.velocity.x, heliBod.velocity.y + .5f, heliBod.velocity.z);
            

            var boostx = Mathf.Sin(yaw * Mathf.Deg2Rad);
            var boostz = Mathf.Cos(yaw* Mathf.Deg2Rad);
            Debug.Log("boostx is " + boostx);
            Debug.Log("boostz is " + boostz);
            heliBod.velocity = new Vector3(heliBod.velocity.x + burstSpeed * -boostx, heliBod.velocity.y + .5f, heliBod.velocity.z + burstSpeed * -boostz);
        } else
        {
            heliBod.velocity = new Vector3(heliBod.velocity.x, heliBod.velocity.y, heliBod.velocity.z);
        }
    }
}
