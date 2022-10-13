using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject tutorialPanel;
    void Start()
    {
        tutorialPanel.SetActive(true);
    }

    void Update()
    {
        if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                tutorialPanel.SetActive(false);
            }
    }
}
