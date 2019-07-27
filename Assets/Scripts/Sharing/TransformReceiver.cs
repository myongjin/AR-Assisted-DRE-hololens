using UnityEngine;

public class TransformReceiver : MonoBehaviour
{

    private TransformProcessor processor;

    [SerializeField]
    private CustomMessages.TestMessageID testMessageId;

    private void Start()
    {
        processor = GetComponent<TransformProcessor>();
        CustomMessages.Instance.MessageHandlers[testMessageId] = processor.ProcessTransform;
    }
}
