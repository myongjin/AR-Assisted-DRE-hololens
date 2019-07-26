using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnusTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hey");
        if (other.gameObject.name == "Finger")
        {
            Debug.Log("ANus");
        }
        if (Game.Instance.GameStage == GameStage.StartTraining && Game.Instance.DREStage == DREStage.Start)
        {
            Game.Instance.DREStage = DREStage.Anus;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Game.Instance.GameStage == GameStage.StartTraining && Game.Instance.DREStage == DREStage.PalpateProstate)
        {
            Game.Instance.DREStage = DREStage.Remove;
        }
    }
}
