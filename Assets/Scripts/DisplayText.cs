using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    public HelicopterHead heli;
    private UnityEngine.UI.Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //replace this with an event!!!
        text.text = (heli.GetCharge().ToString() + " charge and " + heli.GetWind().ToString() + " wind");
    }
}
