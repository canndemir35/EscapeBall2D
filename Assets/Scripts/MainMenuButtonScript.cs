using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour
{
    private Button button;
    private Text buttonText;
    int buttonNumber;
    void Start()
    {
        //PlayerPrefs.SetInt("ChapterSolved", 0);
        button = GetComponent<Button>();
		button.onClick.AddListener(ChaptersButtonClicked);
        buttonText = GetComponentInChildren<Text>();
        buttonNumber = int.Parse(buttonText.text);
        if(buttonNumber > PlayerPrefs.GetInt("ChapterSolved") + 1)
        {
            button.interactable = false;
        }
        else if(buttonNumber <= PlayerPrefs.GetInt("ChapterSolved"))
        {
            button.interactable = true;
        }
    }

    public void ChaptersButtonClicked()
    {
        SceneManager.LoadScene(buttonNumber);
    }
}
