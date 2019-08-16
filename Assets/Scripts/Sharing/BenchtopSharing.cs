using HoloToolkit.Sharing;
using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchtopSharing : MonoBehaviour
{

    public bool IsManipulated = false;
    public CustomMessages.TestMessageID testMessageId;

    private void Start()
    {
        CustomMessages.Instance.MessageHandlers[testMessageId] = processTransform;
    }

    public void Update()
    {
        if (IsManipulated)
        {
            CustomMessages.Instance.SendTransform(CustomMessages.TestMessageID.BenchtopTransform, transform.localPosition, transform.localRotation);
        }
    }

    private void processTransform(NetworkInMessage msg)
    {
        long userID = msg.ReadInt64();         var position = CustomMessages.Instance.ReadVector3(msg);         var rotation = CustomMessages.Instance.ReadQuaternion(msg);
        
        if (!IsManipulated)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
        }
    }
}
