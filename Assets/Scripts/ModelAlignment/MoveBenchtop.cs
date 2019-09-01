using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBenchtop : MonoBehaviour
{
    public float speed = 0.1f;

    private BenchtopSharing benchtopSharing;

    private void Awake()
    {
        benchtopSharing = GetComponent<BenchtopSharing>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveXAxis(bool positive)
    {
        benchtopSharing.IsManipulated = true;
        int direction = positive ? 1 : -1;
        transform.Translate(new Vector3(direction * speed * Time.deltaTime, 0, 0));
    }

    public void MoveYAxis(bool positive)
    {
        benchtopSharing.IsManipulated = true;
        int direction = positive ? 1 : -1;
        transform.Translate(new Vector3(0, direction * speed * Time.deltaTime, 0));
    }
}
