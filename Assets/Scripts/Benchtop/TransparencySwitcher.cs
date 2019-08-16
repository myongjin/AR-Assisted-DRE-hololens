using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencySwitcher : MonoBehaviour
{
    public Renderer Skin;
    public Material OriginalSkin;
    public Material DRESkin;

    private GameManager game;

    // Use this for initialization
    void Start()
    {
        game = GameManager.Instance;

        game.OnTransparencyChange += OnTransparencyChange;

        OnTransparencyChange(true);
    }

    private void OnTransparencyChange(bool isTransparent)
    {
        Skin.material = isTransparent ? DRESkin : OriginalSkin;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
