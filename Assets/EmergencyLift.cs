using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyLift : MonoBehaviour
{
    public float distance;
    RaycastHit rayHit;
    bool deployed;

    // Start is called before the first frame update
    void Start()
    {
        deployed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * distance, Color.red, .001f);
        if (Physics.Raycast(transform.position, Vector3.down, distance))
        {
            if (!deployed)
            {
                InvertBroccoli();
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.up, distance))
        {
            if (deployed)
            {
                RevertBroccoli();
            }
        }

    }

    // Inverts the gravity
    void InvertBroccoli()
    {
        Debug.Log("Gravity has been INverted");
        deployed = true;
        Physics.gravity = new Vector3(0, 3, 0);
    }

    // Reverts the gravity
    void RevertBroccoli()
    {
        Debug.Log("Gravity has been reverted");
        deployed = false;
        Physics.gravity = new Vector3(0, -6, 0);
    }
}
