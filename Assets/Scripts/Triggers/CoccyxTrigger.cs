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

        if (GameManager.Instance.DREStage == DREStage.Rectum)
        {
            GameManager.Instance.DREStage = DREStage.Coccyx;
        }
    }
}
