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
        if (Game.Instance.GameStage == GameStage.StartTraining) return;

        if (Game.Instance.DREStage == DREStage.Start)
        {
            Game.Instance.DREStage = DREStage.Anus;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name != "Finger") return;
        if (Game.Instance.GameStage == GameStage.StartTraining) return;

        if (Game.Instance.DREStage == DREStage.PalpateProstate)
        {
            Game.Instance.DREStage = DREStage.Remove;
        }
    }
}
