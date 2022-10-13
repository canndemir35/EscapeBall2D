using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScriptL : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float angle;
    public bool LBaseOk = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    void Update () 
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            anim.enabled = true;
        }
        
        if(transform.rotation == Quaternion.Euler(0,0,-90))
        {
            LBaseOk = true;
            anim.enabled = false;
        }
    }
}
