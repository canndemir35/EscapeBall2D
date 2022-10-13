using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;

    float upForce;

    public bool isGround;

    public GameObject LCircle;
    public bool Lbaseok = false;
    public GameObject RCircle;
    public bool Rbaseok = false;

    public GameObject sceneManager;

    public bool isObstacle;
    public bool isFinish;

    public bool startTime;
    public bool endTime;
    public bool finishStartTime;
    public bool finishEndTime;

    Animator anim;
    AudioSource audio;
    public AudioClip playerJumpAudio;
    public AudioClip playerEndAudio;
    public AudioClip finishAudio;
    public float xMovement = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Lbaseok = LCircle.GetComponent<BaseScriptL>().LBaseOk;
        Rbaseok = RCircle.GetComponent<BaseScriptR>().RBaseOk;
        startTime = sceneManager.GetComponent<Manager>().startTime;
        endTime = sceneManager.GetComponent<Manager>().endTime;
        finishStartTime = sceneManager.GetComponent<Manager>().finishStartTime;
        finishEndTime = sceneManager.GetComponent<Manager>().finishEndTime;
        anim.enabled = false;
        audio = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {
        Lbaseok = LCircle.GetComponent<BaseScriptL>().LBaseOk;
        Rbaseok = RCircle.GetComponent<BaseScriptR>().RBaseOk;
        startTime = sceneManager.GetComponent<Manager>().startTime;
        endTime = sceneManager.GetComponent<Manager>().endTime;
        finishStartTime = sceneManager.GetComponent<Manager>().finishStartTime;
        finishEndTime = sceneManager.GetComponent<Manager>().finishEndTime;
        upForce = 6500f;

        if(startTime == true)
        {
            rb.velocity = Vector3.zero;
            isGround = false;
            anim.enabled = true;
        }

        if(finishStartTime == true)
        {
            isGround = false;
        }

        if(Lbaseok == true && Rbaseok == true)
        {
            rb.gravityScale = 2.0f;   
        }
        else
        {
            rb.gravityScale = 0.0f;
        }
        if(isGround == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                rb.AddForce(new Vector2(0, upForce * Time.deltaTime));
                audio.PlayOneShot(playerJumpAudio, 0.25f);
            }
        }   
    }
   
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        else if(other.gameObject.tag == "Obstacle")
        {
            isObstacle = true;
            audio.PlayOneShot(playerEndAudio, 1.5f);
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else if(other.gameObject.tag == "TurningCircle")
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            isGround = true;
            //rb.constraints = RigidbodyConstraints2D.None;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Finish")
        {
            isFinish = true;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            audio.PlayOneShot(finishAudio, 1.3f);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGround = false;
        }
        else if(other.gameObject.tag == "TurningCircle")
        {
            isGround = false;
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
    
}
