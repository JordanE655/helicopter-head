using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerInput
{
    void InitializeInput(GameObject gameObj);
    bool GetPause();
    void SetCursor();
    float GetAxisX();
    float GetAxisY();
    bool GetFlightHeld();
    bool GetFlightDown();
    bool GetFlightUp();
    bool IsMobile();
    void RotateHead(GameObject gameObj);
}
