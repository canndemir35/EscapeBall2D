using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryPanelAudio : MonoBehaviour
{
    public AudioClip [] loseAudioClip = {};
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        int randomNumber;
        randomNumber = Random.Range(0, loseAudioClip.Length);
        audio.PlayOneShot(loseAudioClip[randomNumber], 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
