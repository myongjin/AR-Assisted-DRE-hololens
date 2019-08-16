using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectOrganButton : MonoBehaviour
{

    public float speed = 0.2f;
    public Vector3 EnlargedPosition = new Vector3(1, 360, 23);
    public float Scale = 2;
    private Vector3 expectedPosition;
    private Vector3 expectedScale = Vector3.one;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, expectedPosition, speed);
        transform.localScale = Vector3.Lerp(transform.localScale, expectedScale, speed);
    }

    public void SetOrganInspected(bool isInspected)
    {
        expectedPosition = isInspected ? EnlargedPosition : Vector3.zero;
        expectedScale = isInspected ? new Vector3(Scale, Scale, Scale) : Vector3.one;
    }
}
