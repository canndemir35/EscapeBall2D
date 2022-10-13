using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScipt : MonoBehaviour
{

    Rigidbody2D rb;
    public float revSpeed;
    bool flip = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(flip == true)
        {
            rb.MoveRotation(rb.rotation + revSpeed * Time.fixedDeltaTime);
        }
        
    }

    
    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            flip = true;
        }
    }
}
