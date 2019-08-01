﻿using HoloToolkit.Examples.InteractiveElements;
using UnityEngine;

public class UISwitcher : MonoBehaviour
{
    public GameObject ErrorPanel;
    public GameObject TrainingPanel;
    public Interactive ReAlignButton; 

    private Game game;

    // Use this for initialization
    private void Start()
    {
        game = Game.Instance;

        game.OnGameStageChange += OnGameStageChange;
    }

    private void OnGameStageChange(GameStage gameStage)
    {
        ErrorPanel.SetActive(gameStage == GameStage.AlignModel);
        TrainingPanel.SetActive(gameStage == GameStage.StartTraining);
        ReAlignButton.IsEnabled = (gameStage == GameStage.StartTraining);
    }

    // Update is called once per frame
    private void Update()
    {

    }
}
