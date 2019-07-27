using UnityEngine;

public class ForceReceiver : MonoBehaviour {

    private ForceProcessor processor;

    [SerializeField]
    private CustomMessages.TestMessageID testMessageId = CustomMessages.TestMessageID.Force;

    private void Start()
    {
        processor = GetComponent<ForceProcessor>();
        CustomMessages.Instance.MessageHandlers[testMessageId] = processor.ProcessForce;
    }
}
