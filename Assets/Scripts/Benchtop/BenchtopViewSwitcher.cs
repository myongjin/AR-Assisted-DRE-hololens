using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchtopViewSwitcher : MonoBehaviour
{
    public GameObject anatomyGroup;

    private Game game;

	// Use this for initialization
	void Start ()
    {
        game = Game.Instance;

        game.OnModelViewChange += OnModelViewChange;
        game.OnProstateChange += OnProstateChange;

        ShowSkin();
	}

    private void OnProstateChange(ProstateType prostate)
    {
        Debug.Log(prostate.ToString());
        anatomyGroup.GetComponent<GroupAnatomy>().ShowProstate(prostate.ToString());
    }

    private void OnModelViewChange(ModelView modelView)
    {
        Debug.Log(modelView);
        switch (modelView)
        {
            case ModelView.Skin:
                ShowSkin();
                break;
            case ModelView.Prostate:
                ShowProstate();
                break;
            case ModelView.Anatomy:
                ShowAnatomy();
                break;
            default:
                ShowSkin();
                break;
        }
    }

    public void ShowSkin()
    {
        anatomyGroup.GetComponent<GroupAnatomy>().ShowNormalBenchtop();
    }

    public void ShowProstate()
    {
        anatomyGroup.GetComponent<GroupAnatomy>().ShowTransparentBenchtop();
        anatomyGroup.GetComponent<GroupAnatomy>().ShowProstate("Normal");
    }

    public void ShowAnatomy()
    {
        anatomyGroup.GetComponent<GroupAnatomy>().ShowTransparentAnatomy();
        anatomyGroup.GetComponent<GroupAnatomy>().ShowProstate("Normal");
    }
}
