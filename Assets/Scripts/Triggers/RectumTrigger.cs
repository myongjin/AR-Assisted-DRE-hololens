using UnityEngine;

public class RectumTrigger : MonoBehaviour
{

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Finger")) return;

        if (GameManager.Instance.DREStage == DREStage.Anus)
        {
            Debug.Log("Rectum");
            GameManager.Instance.DREStage = DREStage.Rectum;
        }
    }
}
