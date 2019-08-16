using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchtopLabelManagement : MonoBehaviour
{
    public GameObject[] tooltips;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        SetShowLabel(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetShowLabel(bool show)
    {
        GameManager.Instance.ShowLabel = show;

        foreach (GameObject go in tooltips)
        {
            go.SetActive(show);
        }
    }
}
