using UnityEngine;

public class DREManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartDRETraining()
    {
        GameManager.Instance.DREStage = DREStage.Start;
    }
}
