using System;
using UnityEngine;
using UnityEngine.Events;

public class HelicopterEvents : MonoBehaviour
{
    public static HelicopterEvents instance;

    private void Awake()
    {
            instance = this;
    }

    public event Action myFirstAction;
    
    public void BoostTriggered()
    {
        if (myFirstAction != null)
        {
            myFirstAction();
        }
    }
}
