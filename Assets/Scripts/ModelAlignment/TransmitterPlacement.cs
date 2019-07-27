using HoloToolkit.Examples.InteractiveElements;
using UnityEngine;
using Vuforia;

public class TransmitterPlacement : MonoBehaviour
{
    public Transform WorldStage;

    private InteractiveToggle interactive;

    private void Start()
    {
        interactive = GetComponent<InteractiveToggle>();
    }

    public void SetTransmitterPosition(Transform targetTransform)
    {
        WorldStage.position = targetTransform.position;
        WorldStage.rotation = targetTransform.rotation;

        GameManager.SetAlignModelGameStage();
        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        interactive.HasSelection = false;
    }

    public void RestartTransmitterTracking()
    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
    }

    public void CancelTransmitterTracking()
    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
    }
}
