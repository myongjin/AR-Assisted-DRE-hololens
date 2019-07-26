using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct TooltipPosition
{
    public LabelPositionCalculator positioner;
    public Vector3 projectedPosition;
    public float angle;
}

public class LabelPositionAttacher : MonoBehaviour {

    public Transform centre;
    public float offsetAngle;

    private Camera cam;
    private Vector3 normal;

    private GameObject[] tooltips;
    private TooltipPosition[] tooltipPositioners;
    //private LabelPositionCalculator[] positioners;
    //private float[] angles;

    // Use this for initialization
    void Start () {
        cam = Camera.main;

        tooltips = GameObject.FindGameObjectsWithTag("ToolTip");
        tooltipPositioners = new TooltipPosition[tooltips.Length];
        //angles = new float[tooltips.Length];
        int i = 0;
        foreach (GameObject tooltip in tooltips)
        {
            tooltip.AddComponent<LabelPositionCalculator>();
            tooltipPositioners[i].positioner = tooltip.GetComponent<LabelPositionCalculator>();
            tooltipPositioners[i].positioner.objectRadius = 0.33f;
            tooltipPositioners[i].positioner.centre = centre;
            Transform tooltipTransform = tooltip.transform;
            foreach (Transform child in tooltipTransform)
            {
                if (child.gameObject.name == "Pivot")
                {
                    tooltipPositioners[i].positioner.pivot = child;
                }

                if (child.gameObject.name == "Anchor")
                {
                    tooltipPositioners[i].positioner.anchor = child;
                }
            }
            i += 1;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        normal = cam.transform.position - centre.position;

        CalculateAngles();

        Array.Sort(tooltipPositioners, (x, y) => x.angle.CompareTo(y.angle));

        //string text = "";
        //for (int i = 0; i < tooltipPositioners.Length; i++)
        //{
        //    text += tooltipPositioners[i].positioner.name + ": " + tooltipPositioners[i].angle + "\n";
        //}
        //Debug.Log(text);

        
        bool occlusionResolved = false;
        int count = 100;


        string text = "";
        while (!occlusionResolved && count > 0)
        {
            occlusionResolved = true;
            CalculateAngles();
            string anothertext = "";
            for (int i = 0; i < tooltipPositioners.Length; i++)
            {
                anothertext += tooltipPositioners[i].positioner.name + ": " + tooltipPositioners[i].angle + "\n";
            }

            text = "";
            for (int i = 0; i < tooltipPositioners.Length; i++)
            {
                bool isOccludded = false;
                float moveAngle = 0.0f;
                text += tooltipPositioners[i].positioner.gameObject.name + " " + tooltipPositioners[i].angle + " ";

                if (HorizontalDistance(i, NextElem(i)) < 0.14 && VirticalDistance(i, NextElem(i)) < 0.08)
                {
                    text += "R";
                    isOccludded = true;
                    moveAngle -= offsetAngle;
                }

                if (HorizontalDistance(i, PrevElem(i)) < 0.14 && VirticalDistance(i, PrevElem(i)) < 0.05)
                {
                    text += "L";
                    isOccludded = true;
                    moveAngle += offsetAngle;
                }

                text += " " + tooltipPositioners[i].projectedPosition.x + "," + tooltipPositioners[i].projectedPosition.y;

                text += "\n";

                if (!isOccludded)
                {
                    tooltipPositioners[i].positioner.pivot.position = tooltipPositioners[i].positioner.pivotPosition;
                }
                else
                {
                    Quaternion pivotRotation = Quaternion.AngleAxis(moveAngle, normal);
                    //Matrix4x4 mPivot = Matrix4x4.Rotate(rotation);
                    //tooltipPositioners[i].positioner.pivot.position = mPivot.MultiplyPoint3x4(tooltipPositioners[i].positioner.pivotPosition);
                    tooltipPositioners[i].positioner.pivotPosition = tooltipPositioners[i].positioner.pivotPosition.RotateAroundPivot(centre.position, pivotRotation);
                    tooltipPositioners[i].positioner.pivot.position = tooltipPositioners[i].positioner.pivotPosition;
                    //Debug.Log(tooltipPositioners[i].positioner.gameObject.name + " " + moveAngle);
                }
                occlusionResolved &= !isOccludded;

            }
            count -= 1;
        }
        //Debug.Log(text);

    }

    private float HorizontalDistance(int i, int j)
    {
        return Math.Abs(tooltipPositioners[i].projectedPosition.x - tooltipPositioners[j].projectedPosition.x);
    }

    private float VirticalDistance(int i, int j)
    {
        return Math.Abs(tooltipPositioners[i].projectedPosition.y - tooltipPositioners[j].projectedPosition.y);
    }

    private int PrevElem(int i)
    {
        return (i - 1 + tooltipPositioners.Length) % tooltipPositioners.Length;
    }

    private int NextElem(int i)
    {
        return (i + 1) % tooltipPositioners.Length;
    }

    private void CalculateAngles()
    {
        Quaternion rotation = Quaternion.FromToRotation(normal, Vector3.back);
        Matrix4x4 m = Matrix4x4.Rotate(rotation);

        for (int i = 0; i < tooltips.Length; i++)
        {
            tooltipPositioners[i].angle = Vector3.SignedAngle(AnchorToPivotVector(0), AnchorToPivotVector(i), normal);
            if (tooltipPositioners[i].angle < 0)
            {
                tooltipPositioners[i].angle += 360;
            }
            tooltipPositioners[i].projectedPosition = m.MultiplyPoint3x4(tooltipPositioners[i].positioner.pivotPosition);
        }
    }

    private Vector3 AnchorToPivotVector(int elem)
    {
        return tooltipPositioners[elem].positioner.pivotPosition - tooltipPositioners[elem].positioner.anchor.position;
    }
}
