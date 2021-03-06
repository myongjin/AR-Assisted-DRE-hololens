﻿using UnityEngine;

public class ProstateTrigger : MonoBehaviour
{
    [SerializeField]
    private float timeLeft = 3f;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Finger")) return;

        if (GameManager.Instance.DREStage == DREStage.Coccyx)
        {
            Debug.Log("Prostate");
            GameManager.Instance.DREStage = DREStage.Prostate;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Finger")) return;

        if (GameManager.Instance.DREStage == DREStage.Prostate)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Debug.Log("PalpateProstate");
                GameManager.Instance.DREStage = DREStage.PalpateProstate;
            }
        }

    }
}
