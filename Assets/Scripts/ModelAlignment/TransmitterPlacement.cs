using HoloToolkit.Examples.InteractiveElements;
using UnityEngine;
using Vuforia;

public class TransmitterPlacement : MonoBehaviour
{
    public Transform WorldStage;
    public GameObject BenchtopModel;
    public GameObject Finger;
    public TextMesh transmitterRegistrationText;

    private InteractiveToggle interactive;

    private void Start()
    {
        interactive = GetComponent<InteractiveToggle>();
    }

    public void SetTransmitterPosition(Transform targetTransform)
    {
        transmitterRegistrationText.text = "Transmitter Found!";
        WorldStage.position = targetTransform.position;
        WorldStage.rotation = targetTransform.rotation;

        Finger.SetActive(true);
        BenchtopModel.SetActive(true);

        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        interactive.HasSelection = false;
    }

    public void RestartTransmitterTracking()
    {
        transmitterRegistrationText.text = "Finding Transmitter..";
        TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
    }

    public void CancelTransmitterTracking()
    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
    }
}
