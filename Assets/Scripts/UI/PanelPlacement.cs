using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPlacement : MonoBehaviour
{
    [SerializeField]
    private Transform benchtop;
    [SerializeField]
    private Vector3 labelOffset = new Vector3(-0.3f, 0, 0);
    [SerializeField]
    private float speed = 0.2f;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.ShowLabel)
        {
            offset = labelOffset;
        }
        else
        {
            offset = Vector3.zero;
        }

        transform.position = Vector3.Lerp(transform.position, benchtop.position + new Vector3(-0.33f, 0.12f, 0) + offset, speed);
    }
}
