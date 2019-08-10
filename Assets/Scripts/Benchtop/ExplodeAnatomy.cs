using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAnatomy : MonoBehaviour
{
    [SerializeField]
    private Transform bone;
    [SerializeField]
    private Transform colon;
    [SerializeField]
    private Transform urinary;
    [SerializeField]
    private Transform repro;
    [SerializeField]
    private Transform muscle;
    [SerializeField]
    private float speed = 0.2f;

    private Vector3 bonePosition = new Vector3(566, 12, -201);
    private Vector3 urinaryPosition = new Vector3(-443, 17, -247);
    private Vector3 reproPosition = new Vector3(245, 6, -109);
    private Vector3 musclePosition = new Vector3(-254, 5, -69);

    private Vector3 boneExpected = Vector3.zero;
    private Vector3 urinaryExpected = Vector3.zero;
    private Vector3 reproExpected = Vector3.zero;
    private Vector3 muscleExpected = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        ResetSystem();
    }

    // Update is called once per frame
    void Update()
    {
        bone.localPosition = Vector3.Lerp(bone.localPosition, boneExpected, speed);
        urinary.localPosition = Vector3.Lerp(urinary.localPosition, urinaryExpected, speed);
        repro.localPosition = Vector3.Lerp(repro.localPosition, reproExpected, speed);
        muscle.localPosition = Vector3.Lerp(muscle.localPosition, muscleExpected, speed);
    }

    public void ExplodeSystem()
    {
        boneExpected = bonePosition;
        urinaryExpected = urinaryPosition;
        reproExpected = reproPosition;
        muscleExpected = musclePosition;
    }

    public void ResetSystem()
    {
        boneExpected = Vector3.zero;
        urinaryExpected = Vector3.zero;
        reproExpected = Vector3.zero;
        muscleExpected = Vector3.zero;
    }
}
