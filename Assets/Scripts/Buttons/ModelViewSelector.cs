﻿using UnityEngine;
using UnityEngine.Assertions;

public class ModelViewSelector : MonoBehaviour
{
    public void SelectModelView(int view)
    {
        Assert.IsTrue(view < System.Enum.GetValues(typeof(ModelView)).Length);

        Game.Instance.ModelView = (ModelView)view;
    }

    public void SelectProstate(int prostate)
    {
        Assert.IsTrue(prostate < System.Enum.GetValues(typeof(ProstateType)).Length);

        Game.Instance.Prostate = (ProstateType)prostate;
    }
}
