using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchtopViewSwitcher : MonoBehaviour
{

    private Game game;

	// Use this for initialization
	void Start ()
    {
        game = Game.Instance;

        game.OnModelViewChange += OnModelViewChange;
	}

    private void OnModelViewChange(ModelView newVal)
    {
        Debug.Log(newVal);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
