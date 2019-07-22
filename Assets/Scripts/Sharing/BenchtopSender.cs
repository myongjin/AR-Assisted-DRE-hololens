using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchtopSender : MonoBehaviour
{

    //protected Vector3Interpolated Position;
    //protected QuaternionInterpolated Rotation;
    //protected Vector3Interpolated Scale;

    // Use this for initialization
    void Start()
    {
        //Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        CustomMessages.Instance.SendTransform(CustomMessages.TestMessageID.BenchtopTransform, transform.localPosition, transform.localRotation);

        //Position.SetTarget(transform.localPosition);
        //Rotation.SetTarget(transform.localRotation);
        //// Apply transform changes, if any
        //if (Position.HasUpdate() || Rotation.HasUpdate())
        //{
        //    CustomMessages.Instance.SendTransform(CustomMessages.TestMessageID.BenchtopTransform, transform.localPosition, transform.localRotation);
        //}
    }

    //private void LateUpdate()
    //{

    //    // The object was moved locally, so reset the target positions to the current position
    //    Position.Reset(transform.localPosition);
    //    Rotation.Reset(transform.localRotation);
    //    Scale.Reset(transform.localScale);
    //}

    //private void Initialize()
    //{
    //    if (Position == null)
    //    {
    //        Position = new Vector3Interpolated(transform.localPosition);
    //    }
    //    if (Rotation == null)
    //    {
    //        Rotation = new QuaternionInterpolated(transform.localRotation);
    //    }
    //    if (Scale == null)
    //    {
    //        Scale = new Vector3Interpolated(transform.localScale);
    //    }
    //}
}
