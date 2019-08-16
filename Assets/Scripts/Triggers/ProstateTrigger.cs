using UnityEngine;

public class ProstateTrigger : MonoBehaviour
{
    [SerializeField]
    private float timeLeft = 10f;

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

        if (GameManager.Instance.DREStage == DREStage.Coccyx)
        {
            GameManager.Instance.DREStage = DREStage.Prostate;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name != "Finger") return;

        if (GameManager.Instance.DREStage == DREStage.Prostate)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                GameManager.Instance.DREStage = DREStage.PalpateProstate;
            }
        }

    }
}
