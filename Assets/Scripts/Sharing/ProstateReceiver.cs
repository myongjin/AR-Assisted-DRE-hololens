using HoloToolkit.Examples.InteractiveElements;
using HoloToolkit.Sharing;
using UnityEngine;

public class ProstateReceiver : MonoBehaviour
{
    [SerializeField]
    private InteractiveSet radialSet;

    [SerializeField]
    private CustomMessages.TestMessageID testMessageId = CustomMessages.TestMessageID.Prostate;

    private void Start()
    {
        CustomMessages.Instance.MessageHandlers[testMessageId] = ProcessProstate;
    }

    public void ProcessProstate(NetworkInMessage msg)
    {
        long userID = msg.ReadInt64();
        var prostate = CustomMessages.Instance.ReadInt(msg);          // change prostate state         GameManager.Instance.Prostate = (ProstateType)prostate;

        // change prostate menu
        for (var i = 0; i < radialSet.Interactives.Count; i++)
        {
            radialSet.Interactives[i].HasSelection = (prostate == i);
        }
    }
}
