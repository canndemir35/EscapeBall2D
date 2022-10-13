using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject Player;
    public GameObject gamePanel;
    Image gamePanelImage;
    public GameObject chapterSuccesfulPanel;
    Image chapterSuccesfulPanelImage;
    public GameObject retryPanel;
    Image retryPanelImage;
    public GameObject boundUp;
    public GameObject boundDown;
    public GameObject boundLeft;
    public GameObject boundRight;
    public Vector3 viewPos;
    public bool isObstacle = false;
    public bool isFinish = false;
    int index;
    public bool startTime;
    public float waitTime;
    public bool endTime;
    public bool finishStartTime;
    public float finishWaitTime;
    public bool finishEndTime;
    AudioSource audio;
    public GameObject chapterSuccesfulAudioButton;
    public GameObject retryAudioButton;
    public Sprite audioOnTexture;
    public Sprite audioOffTexture;
    void Start()
    {
        gamePanel.SetActive(true);
        retryPanel.SetActive(false);
        chapterSuccesfulPanel.SetActive(false);
        viewPos = Player.transform.position;
        isObstacle = Player.GetComponent<PlayerScript>().isObstacle;
        isFinish = Player.GetComponent<PlayerScript>().isFinish;
        audio = Player.GetComponent<AudioSource>();
        index = SceneManager.GetActiveScene().buildIndex;
        gamePanelImage = gamePanel.GetComponent<Image>();
        retryPanelImage = retryPanel.GetComponent<Image>();
        chapterSuccesfulPanelImage = chapterSuccesfulPanel.GetComponent<Image>();
        retryPanelImage.color = gamePanelImage.color;
        chapterSuccesfulPanelImage.color = gamePanelImage.color;
    }

    void FixedUpdate()
    {
        Debug.Log(PlayerPrefs.GetFloat("Audio"));
        audio.volume = PlayerPrefs.GetFloat("Audio");
        if(audio.volume == 0.0f)
        {
            chapterSuccesfulAudioButton.GetComponent<Image>().sprite = audioOffTexture;
            retryAudioButton.GetComponent<Image>().sprite = audioOffTexture;     
        }
        else
        {
            chapterSuccesfulAudioButton.GetComponent<Image>().sprite = audioOnTexture;
            retryAudioButton.GetComponent<Image>().sprite = audioOnTexture;
        }
        
        viewPos = Player.transform.position;
        isObstacle = Player.GetComponent<PlayerScript>().isObstacle;
        isFinish = Player.GetComponent<PlayerScript>().isFinish;

        if(startTime == true)
        {
            waitTime -= Time.deltaTime;
            if(waitTime <= 0)
            {
                waitTime = 0;
                endTime = true;
            }
        }

        if(finishStartTime == true)
        {
            finishWaitTime -= Time.deltaTime;
            if(finishWaitTime <= 0)
            {
                finishWaitTime = 0;
                finishEndTime = true;
            }
        }

        if(viewPos.y > boundUp.transform.position.y)
        {
            startTime = true;
            if(endTime == true)
            {
                gamePanel.SetActive(false);
                retryPanel.SetActive(true);
                chapterSuccesfulPanel.SetActive(false);
            }
        }

        if(viewPos.y < boundDown.transform.position.y)
        {
            startTime = true;
            if(endTime == true)
            {
                gamePanel.SetActive(false);
                retryPanel.SetActive(true);
                chapterSuccesfulPanel.SetActive(false);
            }
            
        }

        if(viewPos.x < boundLeft.transform.position.x)
        {
            startTime = true;
            if(endTime == true)
            {
                gamePanel.SetActive(false);
                retryPanel.SetActive(true);
                chapterSuccesfulPanel.SetActive(false);
            }
        }

        if(viewPos.x > boundRight.transform.position.x)
        {
            startTime = true;
            if(endTime == true)
            {
                gamePanel.SetActive(false);
                retryPanel.SetActive(true);
                chapterSuccesfulPanel.SetActive(false);
            }
        }

        if(isObstacle == true)
        {
            startTime = true;
            if(endTime == true)
            {
                gamePanel.SetActive(false);
                retryPanel.SetActive(true);
                chapterSuccesfulPanel.SetActive(false);
            }
        }

        if(isFinish == true)
        {
            finishStartTime = true;
            if(finishEndTime == true)
            {
                gamePanel.SetActive(false);
                retryPanel.SetActive(false);
                chapterSuccesfulPanel.SetActive(true);
            }
        }
    }

    public void retryButtonPressed()
    {
        SceneManager.LoadScene(index);
    }

    public void nextChapterButtonPressed()
    {
        SceneManager.LoadScene(index+1);
    }

    public void previousChapterButtonPressed()
    {
        SceneManager.LoadScene(index-1);
    }

    public void backHomeButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void audioButton()
    {
        if(audio.volume == 1.0f)
        {
            PlayerPrefs.SetFloat("Audio", 0.0f);
        }
        else
        {
            PlayerPrefs.SetFloat("Audio", 1.0f);
        }
    }
}
