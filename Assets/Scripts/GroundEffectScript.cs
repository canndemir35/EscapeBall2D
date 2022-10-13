using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundEffectScript : MonoBehaviour
{
    SpriteRenderer SR;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            SR.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
    }
}
