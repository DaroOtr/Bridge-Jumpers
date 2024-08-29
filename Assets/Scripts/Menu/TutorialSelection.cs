using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSelection : MonoBehaviour
{
    [SerializeField] private GameObject buttonSelectedSprite;
    [SerializeField] private GameObject buttonDisableSprite;
    private bool runTutorial;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("RunTutorial") == 1)
        {
            runTutorial = true;
            buttonDisableSprite.SetActive(false);
            buttonSelectedSprite.SetActive(true);
        }
        else
        {
            runTutorial = false;
            buttonDisableSprite.SetActive(true);
            buttonSelectedSprite.SetActive(false);
        }
    }

    public void TogleTutorial()
    {
        if (runTutorial)
        {
            runTutorial = false;
            buttonDisableSprite.SetActive(true);
            buttonSelectedSprite.SetActive(false);
        }
        else
        {
            runTutorial = true;
            buttonDisableSprite.SetActive(false);
            buttonSelectedSprite.SetActive(true);
        }

    }

    public void SavePrefs()
    {
        if (runTutorial)
            PlayerPrefs.SetInt("RunTutorial",1);
        else
            PlayerPrefs.SetInt("RunTutorial",0);
        
        PlayerPrefs.Save();
    }
}