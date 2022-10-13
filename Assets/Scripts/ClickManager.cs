using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    AudioSource buttonAudio;
    public AudioClip buttonClick;

    void Start()
    {
        buttonAudio = GetComponent<AudioSource>();
    }

    public void clickSound()
    {
        buttonAudio.PlayOneShot(buttonClick, 0.3f);
    }
}
