using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchtopLabelManager : MonoBehaviour
{
    private GameObject[] tooltips;

    private void Awake()
    {
        tooltips = GameObject.FindGameObjectsWithTag("BenchToolTip");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVisibleTooltip(bool show)
    {
        foreach (GameObject tooltip in tooltips)
        {
            tooltip.SetActive(show);
        }
    }
}
