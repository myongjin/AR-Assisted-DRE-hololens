﻿using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStage
{
    FindTransmitter,
    AlignModel,
    StartTraining
}

public enum ModelView
{
    Skin,
    Prostate,
    Anatomy
}

public enum ProstateType
{
    Normal,
    UnilateralBenign,
    BilateralBenign,
    UnilateralCarcinoma,
    BilateralCarcinoma
}

public class Game : Singleton<Game>
{
    public event OnGameStageChangeDelegate OnGameStageChange;
    public delegate void OnGameStageChangeDelegate(GameStage gameStage);

    public event OnModelViewChangeDelegate OnModelViewChange;
    public delegate void OnModelViewChangeDelegate(ModelView modelView);

    public event OnProstateChangeDelegate OnProstateChange;
    public delegate void OnProstateChangeDelegate(ProstateType prostate);

    [SerializeField]
    private GameStage _gameStage = GameStage.FindTransmitter;
    public GameStage GameStage
    {
        get
        {
            return _gameStage;
        }
        set
        {
            if (_gameStage == value) return;
            _gameStage = value;
            if (OnGameStageChange != null)
                OnGameStageChange(_gameStage);
        }
    }

    [SerializeField]
    private ModelView _modelView = ModelView.Skin;
    public ModelView ModelView
    {
        get
        {
            return _modelView;
        }
        set
        {
            if (_modelView == value) return;
            _modelView = value;
            if (OnModelViewChange != null)
                OnModelViewChange(_modelView);
        }
    }

    [SerializeField]
    private ProstateType _prostate = ProstateType.Normal;
    public ProstateType Prostate
    {
        get
        {
            return _prostate;
        }
        set
        {
            if (_prostate == value) return;
            _prostate = value;
            if (OnProstateChange != null)
                OnProstateChange(_prostate);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Prostate = (ProstateType)(((int)Prostate + 1) % 3);
        }
    }
}
