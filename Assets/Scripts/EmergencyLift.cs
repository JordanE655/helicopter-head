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

    }

    // Fixed Update is called at a consistent rate
    private void FixedUpdate()
    {
        
    }
}
