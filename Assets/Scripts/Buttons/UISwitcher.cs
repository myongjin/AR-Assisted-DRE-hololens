using HoloToolkit.Examples.InteractiveElements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitcher : MonoBehaviour
{
    public GameObject errorPanel;
    public GameObject trainingPanel;

    public GameObject checkboxInsertFinger;
    public GameObject checkboxProstateFound;
    public GameObject checkboxPalpateProstate;
    public GameObject checkboxRemoveFinger;

    private Game game;

    // Use this for initialization
    void Start ()
    {
        game = Game.Instance;

        game.OnGameStageChange += OnGameStageChange;

        game.OnDREStageChange += OnDREStageChange;
    }

    private void OnDREStageChange(DREStage dreStage)
    {
        switch (dreStage)
        {
            case DREStage.Start:
                checkboxInsertFinger.GetComponent<InteractiveToggle>().HasSelection = false;
                checkboxProstateFound.GetComponent<InteractiveToggle>().HasSelection = false;
                checkboxPalpateProstate.GetComponent<InteractiveToggle>().HasSelection = false;
                checkboxRemoveFinger.GetComponent<InteractiveToggle>().HasSelection = false;
                break;
            case DREStage.Anus:
                checkboxInsertFinger.GetComponent<InteractiveToggle>().HasSelection = true;
                checkboxProstateFound.GetComponent<InteractiveToggle>().HasSelection = false;
                checkboxPalpateProstate.GetComponent<InteractiveToggle>().HasSelection = false;
                checkboxRemoveFinger.GetComponent<InteractiveToggle>().HasSelection = false;
                break;
            case DREStage.Rectum:
                checkboxInsertFinger.GetComponent<InteractiveToggle>().HasSelection = true;
                checkboxProstateFound.GetComponent<InteractiveToggle>().HasSelection = false;
                checkboxPalpateProstate.GetComponent<InteractiveToggle>().HasSelection = false;
                checkboxRemoveFinger.GetComponent<InteractiveToggle>().HasSelection = false;
                break;
            case DREStage.Prostate:
                checkboxInsertFinger.GetComponent<InteractiveToggle>().HasSelection = true;
                checkboxProstateFound.GetComponent<InteractiveToggle>().HasSelection = true;
                checkboxPalpateProstate.GetComponent<InteractiveToggle>().HasSelection = false;
                checkboxRemoveFinger.GetComponent<InteractiveToggle>().HasSelection = false;
                break;
            case DREStage.PalpateProstate:
                checkboxInsertFinger.GetComponent<InteractiveToggle>().HasSelection = true;
                checkboxProstateFound.GetComponent<InteractiveToggle>().HasSelection = true;
                checkboxPalpateProstate.GetComponent<InteractiveToggle>().HasSelection = true;
                checkboxRemoveFinger.GetComponent<InteractiveToggle>().HasSelection = false;
                break;
            case DREStage.Remove:
                checkboxInsertFinger.GetComponent<InteractiveToggle>().HasSelection = true;
                checkboxProstateFound.GetComponent<InteractiveToggle>().HasSelection = true;
                checkboxPalpateProstate.GetComponent<InteractiveToggle>().HasSelection = true;
                checkboxRemoveFinger.GetComponent<InteractiveToggle>().HasSelection = true;
                break;

        }
    }

    private void OnGameStageChange(GameStage gameStage)
    {
        errorPanel.SetActive(gameStage == GameStage.AlignModel);
        trainingPanel.SetActive(gameStage == GameStage.StartTraining);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
