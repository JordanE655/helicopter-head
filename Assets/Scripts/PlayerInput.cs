using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerInput
{ 
    float GetAxisX();
    float GetAxisY();
    bool GetFlightHeld();
    bool GetFlightDown();
}
