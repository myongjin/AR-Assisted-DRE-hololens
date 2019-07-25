using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelPositionCalculator : MonoBehaviour
{

    public Transform anchor;
    public Transform pivot;
    public Transform centre;
    //public Transform sphere;
    public float objectRadius;
    public Vector3 pivotPosition;

    private Camera cam;
    private Vector3 normal;
    private Plane plane;
    private Vector3 projectedCentre;
    private float radius;
    private Vector3 normalDirection;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        normal = cam.transform.position - anchor.position;

        plane = new Plane(normal.normalized, anchor.position);

        projectedCentre = plane.ClosestPointOnPlane(centre.position);

        normalDirection = (anchor.position - projectedCentre).normalized;

        //pivot.position = projectedCentre + normalDirection * objectRadius;
        pivotPosition = projectedCentre + normalDirection * objectRadius;
    }
}
