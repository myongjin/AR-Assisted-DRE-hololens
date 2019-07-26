using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectumTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (Game.Instance.GameStage == GameStage.StartTraining && Game.Instance.DREStage == DREStage.Anus)
        {
            Game.Instance.DREStage = DREStage.Rectum;
        }
    }
}
