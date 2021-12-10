using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterHead : MonoBehaviour
{
    public PlayerInput playerInput;
    private PlayerPhysics playerPhysics;
    public GameObject heliHead;
    public float x, y, z, w;
    public GameObject pointer;

    // Start is called before the first frame update
    void Start()
    {
        // Asks which device is being used (maybe this shouldn't be handled in the Helicopter Head class)
        // if android, playerInput = new AndroidPlayerInput();
        // maybe in the awake method, we define an enum which can decide which device you're on
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            playerInput = new WindowsPlayerInput();
        } else if ( Application.platform == RuntimePlatform.Android)
        {
            playerInput = new OculusPlayerInput();
            playerInput.InitializeInput(gameObject);
        } else
        {
            playerInput = new WindowsPlayerInput();
        }
        playerPhysics = new PlayerPhysics();

    }

    // Update is called once per frame
    void Update()
    {
        playerPhysics.HeadHandling(heliHead, playerInput);
    }

    private void FixedUpdate()
    {
        Vector3 tryHard = Vector3.Normalize(new Vector3(pointer.transform.position.x - transform.position.x, 0f, pointer.transform.position.z - transform.position.z));
        float chargeTime = playerPhysics.FlightHandling(heliHead.transform.localRotation.eulerAngles, GetComponent<Rigidbody>(), playerInput);
        if (chargeTime > 0f)
        {
            HelicopterEvents.instance.BoostTriggered();
            StartCoroutine(superDash(tryHard, chargeTime));
        }
    }


    // Look at how much this deals directly with wind. This would be hard to trace and edit. Consider decoupling
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            playerPhysics.wind += 1.5f * Time.deltaTime;
            if (playerPhysics.wind >= 1.5f)
            {
                playerPhysics.wind = 1.5f;
            }
        }
    }

    //This feels like a physics thing but whatever
    IEnumerator superDash(Vector3 tums, float chargeTime)
    {
        // suspend execution for 5 seconds
        float startTime = 0;
        Rigidbody rigid = GetComponent<Rigidbody>();

        Vector3 dashVelocity = new Vector3(Vector3.Normalize(tums).x * 20f, Vector3.Normalize(tums).y * 5f, Vector3.Normalize(tums).z * 20f);
        Debug.Log(dashVelocity);
        while (startTime <= chargeTime)
        {
            Debug.Log(rigid.velocity);

            dashVelocity = new Vector3(
                Vector3.MoveTowards(dashVelocity, new Vector3(0f, 20f, 0f), 50f * Time.deltaTime).x,
                Vector3.MoveTowards(dashVelocity, new Vector3(0f, 16f, 0f), 20f* Time.deltaTime).y, // used to be 12
                Vector3.MoveTowards(dashVelocity, new Vector3(0f, 20f, 0f), 50f * Time.deltaTime).z
                );
            rigid.velocity = dashVelocity;
            startTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        print("Honestly Tried " + Time.time);
        
    }

    public float GetCharge()
    {
        return playerPhysics.charge;
    }
    public float GetWind()
    {
        return playerPhysics.wind;
    }
    public float GetWindForUI()
    {
        var physo = playerPhysics.wind/1.5f;
        if (physo >= 1f)
        {
            physo = 0.99f;
        } else if (physo <= 0f)
        {
            physo = 0f;
        }
        return physo;
    }
}
