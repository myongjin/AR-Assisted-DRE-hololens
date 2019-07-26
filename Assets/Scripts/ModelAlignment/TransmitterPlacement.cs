using HoloToolkit.Examples.InteractiveElements;
using UnityEngine;
using Vuforia;

public class TransmitterPlacement : MonoBehaviour
{
    public Transform worldStage;

    private InteractiveToggle interactive;

    private void Start()
    {
        interactive = GetComponent<InteractiveToggle>();
    }

    public void SetTransmitterPosition(Transform targetTransform)
    {
        worldStage.position = targetTransform.position;
        worldStage.rotation = targetTransform.rotation;

        GameManager.SetGameStage();
        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        interactive.HasSelection = false;
    }

    public void RestartTransmiiter()
    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
    }

    public void CancelTransmitterTracking()
    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
    }
}
