using UnityEngine;

public class AnusTrigger : MonoBehaviour
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
        if (other.gameObject.name != "Finger") return;

        if (GameManager.Instance.DREStage == DREStage.Start)
        {
            Debug.Log("Anus");
            GameManager.Instance.DREStage = DREStage.Anus;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name != "Finger") return;

        if (GameManager.Instance.DREStage == DREStage.PalpateProstate)
        {
            GameManager.Instance.DREStage = DREStage.Remove;
        }
    }
}
