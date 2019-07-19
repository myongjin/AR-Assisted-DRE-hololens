using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointerReceiver : MonoBehaviour {

    TransformProcesser processor;

    void Start()
    {
        processor = GetComponent<TransformProcesser>();
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.LaserTransform] = processor.ProcessTransform;
    }
}
