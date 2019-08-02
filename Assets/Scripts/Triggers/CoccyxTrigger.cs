using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoccyxTrigger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Finger") return;
        if (Game.Instance.GameStage != GameStage.StartTraining) return;

        if (Game.Instance.DREStage == DREStage.Rectum)
        {
            Game.Instance.DREStage = DREStage.Coccyx;
        }
    }
}
