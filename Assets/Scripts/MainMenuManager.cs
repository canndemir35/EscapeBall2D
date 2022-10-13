using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject backgroundPanel;
    public GameObject mainPanel;
    public GameObject chaptersPanel;
    public GameObject chapter1Panel;
    public GameObject chapter11Panel;
    public GameObject chapter21Panel;
    public GameObject mainMusicButton;
    public GameObject chaptersMusicButton;
    public Sprite musicOnTexture;
    public Sprite musicOffTexture;
    AudioSource music;
    void Start()
    {
        backgroundPanel.SetActive(true);
        mainPanel.SetActive(true);
        chaptersPanel.SetActive(false);
        chapter1Panel.SetActive(false);
        chapter11Panel.SetActive(false);
        chapter21Panel.SetActive(false);
        music = GetComponent<AudioSource>();
    }

    void Update()
    {
        music.volume = PlayerPrefs.GetFloat("Music");
        if(music.volume == 0.0f)
        {
            mainMusicButton.GetComponent<Image>().sprite = musicOffTexture;
            chaptersMusicButton.GetComponent<Image>().sprite = musicOffTexture;    
        }
        else
        {
            mainMusicButton.GetComponent<Image>().sprite = musicOnTexture;
            chaptersMusicButton.GetComponent<Image>().sprite = musicOnTexture;
        }
    }

    public void playButtonPressed()
    {
        backgroundPanel.SetActive(true);
        mainPanel.SetActive(false);
        chaptersPanel.SetActive(true);
        chapter1Panel.SetActive(false);
        chapter11Panel.SetActive(false);
        chapter21Panel.SetActive(false);
    }

    public void chapters1ButtonPressed()
    {
        backgroundPanel.SetActive(true);
        mainPanel.SetActive(false);
        chaptersPanel.SetActive(false);
        chapter1Panel.SetActive(true);
        chapter11Panel.SetActive(false);
        chapter21Panel.SetActive(false);
    }

    public void chapters11ButtonPressed()
    {
        backgroundPanel.SetActive(true);
        mainPanel.SetActive(false);
        chaptersPanel.SetActive(false);
        chapter1Panel.SetActive(false);
        chapter11Panel.SetActive(true);
        chapter21Panel.SetActive(false);
    }

    public void chapters21ButtonPressed()
    {
        backgroundPanel.SetActive(true);
        mainPanel.SetActive(false);
        chaptersPanel.SetActive(false);
        chapter1Panel.SetActive(false);
        chapter11Panel.SetActive(false);
        chapter21Panel.SetActive(true);
    }

    public void backButtonPressed()
    {
        backgroundPanel.SetActive(true);
        mainPanel.SetActive(true);
        chaptersPanel.SetActive(false);
        chapter1Panel.SetActive(false);
        chapter11Panel.SetActive(false);
        chapter21Panel.SetActive(false);
    }

    public void Button1Pressed()
    {
        SceneManager.LoadScene(1);
    }

    public void Button2Pressed()
    {
        SceneManager.LoadScene(2);
    }

    public void Button3Pressed()
    {
        SceneManager.LoadScene(3);
    }

    public void Button4Pressed()
    {
        SceneManager.LoadScene(4);
    }

    public void Button5Pressed()
    {
        SceneManager.LoadScene(5);
    }

    public void musicButton()
    {
        if(music.volume == 1.0f)
        {
            PlayerPrefs.SetFloat("Music", 0.0f);
        }
        else
        {
            PlayerPrefs.SetFloat("Music", 1.0f);
        }
    }
    
}
