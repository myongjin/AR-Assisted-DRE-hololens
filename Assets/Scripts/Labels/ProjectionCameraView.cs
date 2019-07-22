using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionCameraView : MonoBehaviour
{

    public Transform boneTooltip;
    public Transform muscleTooltip;
    public Transform rectumTooltip;
    public Transform urinaryTooltip;
    public Transform reproTooltip;
    public Transform prostateTooltip;

    public TextMesh textMesh;

    private Camera cam;

	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 boneScreenPos = cam.WorldToScreenPoint(boneTooltip.position);
        Vector3 muscleScreenPos = cam.WorldToScreenPoint(muscleTooltip.position);
        Vector3 rectumScreenPos = cam.WorldToScreenPoint(rectumTooltip.position);
        Vector3 urinaryScreenPos = cam.WorldToScreenPoint(urinaryTooltip.position);
        Vector3 reproScreenPos = cam.WorldToScreenPoint(reproTooltip.position);
        Vector3 prostateScreenPos = cam.WorldToScreenPoint(prostateTooltip.position);

        string text = "";
        text += "bone: " + boneScreenPos.ToString("F2") + "\n";
        text += "muscle: " + muscleScreenPos.ToString("F2") + "\n";
        text += "rectum: " + rectumScreenPos.ToString("F2") + "\n";
        text += "urinary: " + urinaryScreenPos.ToString("F2") + "\n";
        text += "repro: " + reproScreenPos.ToString("F2") + "\n";
        text += "prostate: " + prostateScreenPos.ToString("F2") + "\n";
        textMesh.text = text;

    }
}
