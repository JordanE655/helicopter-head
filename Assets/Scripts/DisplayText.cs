using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    public HelicopterHead heli;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
        HelicopterEvents.instance.myFirstAction += BoostUI;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(heli.GetWind());
        // This is constant, but maybe it should be called with an event ? ?? ? 
        anim.Play("UI Clip", 0, heli.GetWindForUI());
        anim.Play("UI Clip Fill", 2, heli.GetCharge() / 1.5f);
    }

    //Event-based code we'll use events to call! 
    public void BoostUI()
    {
        anim.SetTrigger("Boost");
    }
}
