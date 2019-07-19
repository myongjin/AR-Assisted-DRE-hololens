using UnityEngine;

public class HandPositionReceiver : MonoBehaviour
{
    TransformProcesser processor;

    void Start()
    {
        processor = GetComponent<TransformProcesser>();
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.HandTransform] = processor.ProcessTransform;
    }
}
