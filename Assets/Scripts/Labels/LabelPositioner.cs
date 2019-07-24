﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

struct Tooltip
{
    Transform _gameObject;
    public Transform gameobject
    {
        get
        {
            return _gameObject;
        }
        set
        {
            _gameObject = value;
            foreach (Transform tooltipChild in _gameObject)
            {
                if (tooltipChild.gameObject.name == "Anchor")
                {
                    anchor = tooltipChild;
                }
                else if (tooltipChild.gameObject.name == "Pivot")
                {
                    pivot = tooltipChild;
                }
            }
        }
    }
    public Transform anchor;
    public Transform pivot;

    public Vector3 projectedAnchor;
    public float angle;
}

public class LabelPositioner : MonoBehaviour
{
    public Transform centre;
    public Transform right;

    private Tooltip[] tooltipCollection;
    //private Transform[] anchors;
    //private Transform[] pivots;

    private Camera cam;

    private Vector3 normal;
    private Plane plane;
    //private Vector3[] projectedAnchors;
    //private float[] angles;
    //private int[] order;

    // Use this for initialization
    void Start ()
    {
        cam = Camera.main;

        GameObject[] tooltips = GameObject.FindGameObjectsWithTag("ToolTip");
        tooltipCollection = new Tooltip[tooltips.Length];

        for (int i = 0; i < tooltips.Length; i++)
        {
            tooltipCollection[i].gameobject = tooltips[i].transform;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        // find plane
        normal = centre.position - cam.transform.position;
        plane = new Plane(normal.normalized, centre.position);

        string text = "";
        // project anchors to the plane
        for (int i = 0; i < tooltipCollection.Length; i++)
        {
            tooltipCollection[i].projectedAnchor = plane.ClosestPointOnPlane(tooltipCollection[i].anchor.position);
            //if (projectedAnchors[i].z < 0) return;


            //text += tooltips[i].name + ": " + projectedAnchors[i].ToString("F2") + "\n";
        }
        //Debug.Log(text);

        Vector3 projectedCentre = plane.ClosestPointOnPlane(centre.position);

        Vector3 rightViewport = cam.WorldToViewportPoint(centre.position) + 0.4f * Vector3.right;

        Ray ray = cam.ViewportPointToRay(rightViewport);

        float enter = 0.0f;
        Vector3 hitPoint = Vector3.zero;
        if (plane.Raycast(ray, out enter))
        {
            hitPoint = ray.GetPoint(enter);
            right.transform.position = hitPoint;
        }
        
        Vector3 zeroAngle = hitPoint - projectedCentre;

        float angle;
        for (int i = 0; i < tooltipCollection.Length; i++)
        {
            angle = Vector3.SignedAngle(zeroAngle, tooltipCollection[i].projectedAnchor - projectedCentre, normal);
            if (angle < 0)
            {
                angle = 360 + angle;
            }
            tooltipCollection[i].angle = angle;
            //text += tooltips[i].name + ": " + angle.ToString("F2") + "\n";
        }
        //Debug.Log(text);
        Array.Sort(tooltipCollection, (x, y) => x.angle.CompareTo(y.angle));
        //Array.Sort(theArray, (x, y) => string.Compare(x.Artist, y.Artist));

        // print all element of array 
        float newAngle = 0;
        float angleStep = 360f / tooltipCollection.Length;
        Vector3 newZeroPoint = projectedCentre + 0.33f * zeroAngle.normalized;
        foreach (Tooltip tooltip in tooltipCollection)
        {
            newAngle += angleStep;
            tooltip.pivot.position = newZeroPoint.RotateAroundPivot(centre.position, Quaternion.AngleAxis(newAngle, normal));
            text += tooltip.gameobject.name + " " + tooltip.angle.ToString("F2") + "\n";
        }

        Debug.Log(text);
        
    }
}
