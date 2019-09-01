using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProstateSwitcher : MonoBehaviour
{
    public Transform Prostate;

    private GameManager game;

    // Use this for initialization
    void Start()
    {
        game = GameManager.Instance;

        game.OnProstateChange += OnProstateChange;

        OnProstateChange(ProstateType.Normal);
    }

    private void OnProstateChange(ProstateType prostateType)
    {
        foreach (Transform child in Prostate)
        {
            child.gameObject.SetActive(child.gameObject.name == prostateType.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
