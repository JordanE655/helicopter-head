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
    }

    // Update is called once per frame
    void Update()
    {
        //replace this with an event!!!
        Debug.Log(heli.GetWind());
        anim.Play("UI Clip", 0, heli.GetWind()/1.5f);
        //anim["UI Clip"].time = heli.GetWind();
    }
}
