using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity;
using UnityEngine;

public class CameraPlane : Singleton<CameraPlane>
{

    public Transform CamTransform;
    public Transform Centre;
    public Vector3 Normal;

    // Use this for initialization
    private void Start()
    {
        CamTransform = transform;

    }

    // Update is called once per frame
    private void Update()
    {
        Normal = CamTransform.position - Centre.position;
    }
}
