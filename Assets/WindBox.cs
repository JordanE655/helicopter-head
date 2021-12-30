using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBox : MonoBehaviour
{
    public bool permanent = false;
    private bool attainable = true;
    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public bool FillWind()
    {
        if (permanent)
        {
            return true;
        }
        if (attainable)
        {
            gameObject.layer = 1;
            anim.SetTrigger("Collected");
            attainable = false;
            return true;
        }
        return false;
    }

    public void ResetWind()
    {
        gameObject.layer = 9;
        attainable = true;
    }
}
