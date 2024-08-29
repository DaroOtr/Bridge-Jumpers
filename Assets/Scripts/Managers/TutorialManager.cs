using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialPanel;
    [SerializeField] private TextMeshProUGUI _tutorialLabel;
    [SerializeField] private Animator _tutoriaAnimator;
    [SerializeField] private GameObject _firstStep;
    [SerializeField] private GameObject _secondStep;

    private void Start()
    {
        if (PlayerPrefs.GetInt("RunTutorial") == 1)
        {
            _tutorialPanel.SetActive(true);
            FirstStep();
        }
        else
        {
            _tutorialPanel.SetActive(false);
            _firstStep.SetActive(false);
            _secondStep.SetActive(false);
        }
    }

    public void FirstStep()
    {
        _tutorialLabel.text = "Slide UP To Jump or Down to Quick Fall";
        _tutoriaAnimator.SetBool("Click",true);
        _firstStep.SetActive(true);
        _secondStep.SetActive(false);
    }

    public void SecondStep()
    {
        _tutorialLabel.text = "Slide To The Sides To Move";
        _tutoriaAnimator.SetBool("Click",false);
        _firstStep.SetActive(false);
        _secondStep.SetActive(true);
    }

    public void FinishTutorial()
    {
        PlayerPrefs.SetInt("RunTutorial",0);
        _tutorialPanel.SetActive(false);
    }
}
