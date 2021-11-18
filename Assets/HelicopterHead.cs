using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterHead : MonoBehaviour
{
    public PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        // Asks which device is being used (maybe this shouldn't be handled in the Helicopter Head class)
        // if android, playerInput = new AndroidPlayerInput();
        // maybe in the awake method, we define an enum which can decide which device you're on
        if (true)
        {
            playerInput = new WindowsPlayerInput();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInput.InputHandling(this.gameObject);
    }
}
