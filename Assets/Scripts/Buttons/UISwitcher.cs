using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitcher : MonoBehaviour
{
    public GameObject errorPanel;
    public GameObject trainingPanel;

    private Game game;

    // Use this for initialization
    void Start ()
    {
        game = Game.Instance;

        game.OnGameStageChange += OnGameStageChange;
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
