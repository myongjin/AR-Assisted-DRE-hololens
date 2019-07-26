using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProstateTrigger : MonoBehaviour {
    
    private float timeLeft = 10f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (Game.Instance.GameStage == GameStage.StartTraining && Game.Instance.DREStage == DREStage.Rectum)
        {
            Game.Instance.DREStage = DREStage.Prostate;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Game.Instance.GameStage == GameStage.StartTraining && Game.Instance.DREStage == DREStage.Rectum)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Game.Instance.DREStage = DREStage.PalpateProstate;
            }
        }
        
    }
}
