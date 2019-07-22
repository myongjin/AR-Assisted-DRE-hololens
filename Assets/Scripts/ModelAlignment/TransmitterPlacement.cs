using UnityEngine;
using Vuforia;

public class TransmitterPlacement : MonoBehaviour
{

	public void RestartTransmiiter()
    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
    }
}
