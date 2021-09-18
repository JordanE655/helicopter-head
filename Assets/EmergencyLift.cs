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
                DeployBroccoli();
            }
        }

    }

    void DeployBroccoli()
    {
        Debug.Log("It's deployed");
        deployed = true;
        Physics.gravity = new Vector3(0, 3, 0);
    }
}
