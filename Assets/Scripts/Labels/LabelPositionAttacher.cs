﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct TooltipPosition
{
    public LabelPositionCalculator positioner;
    public Vector3 projectedPosition;
    public float angle;
    public Vector3 ProjectedPivot2D;
}

public class LabelPositionAttacher : MonoBehaviour
{
    [SerializeField]
    private bool showLabels = false;
    [SerializeField]
    private float timeStart = 1f;
    [SerializeField]
    private float timeLeft = 1f;
    [SerializeField]
    private float horizontal = 0.14f;
    [SerializeField]
    private float vertical = 0.08f;
    [SerializeField]
    private float offsetAngle = 1f;
    public Transform centre;
    public Transform pelvicAnatomy;
    public float ThresholdAngle = 0f;
    private Vector3 lastNotOccludedCamPos = Vector3.zero;

    private Camera cam;
    private Vector3 normal;

    private List<GameObject> tooltips = new List<GameObject>();
    private TooltipPosition[] tooltipPositioners;
    private BenchtopLabelManagement benchtopLabelManagement;
    //private LabelPositionCalculator[] positioners;
    //private float[] angles;

    // Use this for initialization
    void Awake()
    {
        cam = Camera.main;

        benchtopLabelManagement = GetComponent<BenchtopLabelManagement>();

        SetActiveToolTips();
    }

    public void SetActiveToolTips()
    {
        tooltips.Clear();
        foreach (GameObject tooltip in benchtopLabelManagement.tooltips)
        {
            if (tooltip.activeInHierarchy)
            {
                tooltips.Add(tooltip);
            }
        }

        //foreach (GameObject tooltip in benchtopLabelManagement.tooltips)
        //{
        //    tooltips.Add(tooltip);
        //}

        Debug.Log("Length: " + tooltips.Count);
        tooltipPositioners = new TooltipPosition[tooltips.Count];
        //angles = new float[tooltips.Length];
        int i = 0;
        foreach (GameObject tooltip in tooltips)
        {
            if (tooltip.GetComponent<LabelPositionCalculator>() == null)
            {
                tooltip.AddComponent<LabelPositionCalculator>();
            }
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
    void Update()
    {
        //if (!showLabels) return;

        normal = cam.transform.position - centre.position;

        CalculateAngles();

        Array.Sort(tooltipPositioners, (x, y) => x.angle.CompareTo(y.angle));

        if (GetOcclusion())
        {

            if (Vector3.Angle(lastNotOccludedCamPos, normal) > ThresholdAngle)
            {
                // fix occlusion
                FixOcclusion();
            }

        } else
        {
            lastNotOccludedCamPos = normal;
        }



    }

    private void PrintAngles()
    {
        string text = "";
        for (int i = 0; i < tooltipPositioners.Length; i++)
        {
            text += tooltipPositioners[i].positioner.name + ": " + tooltipPositioners[i].angle + "\n";
        }

        Debug.Log(text);
    }

    private bool GetOcclusion()
    {

        for (var i = 0; i < tooltips.Count; i++)
        {
            var prev = (i - 1 + tooltips.Count) % tooltips.Count;
            var next = (i + 1) % tooltips.Count;

            var currentPrev2DDistance = Pivot2DDistance(i, prev);
            var currentNext2DDistance = Pivot2DDistance(i, next);

            if (Math.Abs(currentPrev2DDistance.x) < horizontal && Math.Abs(currentPrev2DDistance.y) < vertical) return true;
            if (Math.Abs(currentNext2DDistance.x) < horizontal && Math.Abs(currentNext2DDistance.y) < vertical) return true;
        }

        return false;
    }

    private void FixOcclusion()
    {
        bool occlusionResolved = false;
        int count = 100;
        while (!occlusionResolved && count > 0)
        {
            occlusionResolved = true;
            CalculateAngles();

            for (int i = 0; i < tooltipPositioners.Length; i++)
            {
                bool isOccludded = false;
                float moveAngle = 0.0f;

                var prev = (i - 1 + tooltips.Count) % tooltips.Count;
                var next = (i + 1) % tooltips.Count;

                var currentPrevCalculated2DDistance = CalculatedPivot2DDistance(i, prev);
                var currentNextCalculated2DDistance = CalculatedPivot2DDistance(i, next);

                var curPrevX = Math.Abs(currentPrevCalculated2DDistance.x);
                var curPrevY = Math.Abs(currentPrevCalculated2DDistance.y);
                var curNextX = Math.Abs(currentNextCalculated2DDistance.x);
                var curNextY = Math.Abs(currentNextCalculated2DDistance.y);

                if (curNextX < horizontal && curNextY < vertical)
                {
                    isOccludded = true;
                    moveAngle -= offsetAngle;
                }

                if (curPrevX < horizontal && curPrevY < vertical)
                {
                    isOccludded = true;
                    moveAngle += offsetAngle;
                }

                if (!isOccludded)
                {
                    tooltipPositioners[i].positioner.ProposedPivotPosition = tooltipPositioners[i].positioner.pivotPosition;
                }
                else
                {
                    Quaternion pivotRotation = Quaternion.AngleAxis(moveAngle, normal);
                    tooltipPositioners[i].positioner.pivotPosition = tooltipPositioners[i].positioner.pivotPosition.RotateAroundPivot(centre.position, pivotRotation);
                    tooltipPositioners[i].positioner.ProposedPivotPosition = tooltipPositioners[i].positioner.pivotPosition;
                }
                occlusionResolved &= !isOccludded;

            }
            count -= 1;
        }
    }

    private void CalculateAngles()
    {
        Quaternion rotation = Quaternion.FromToRotation(normal, Vector3.back);
        Matrix4x4 m = Matrix4x4.Rotate(rotation);

        for (int i = 0; i < tooltips.Count; i++)
        {
            tooltipPositioners[i].angle = Vector3.SignedAngle(AnchorToPivotVector(0), AnchorToPivotVector(i), normal);
            if (tooltipPositioners[i].angle < 0)
            {
                tooltipPositioners[i].angle += 360;
            }
            tooltipPositioners[i].projectedPosition = m.MultiplyPoint3x4(tooltipPositioners[i].positioner.pivotPosition);

            tooltipPositioners[i].ProjectedPivot2D = m.MultiplyPoint3x4(tooltipPositioners[i].positioner.ProjectedPivot);
        }
    }

    private Vector3 Pivot2DDistance(int i, int j)
    {
        return tooltipPositioners[i].ProjectedPivot2D - tooltipPositioners[j].ProjectedPivot2D;
    }

    private Vector3 CalculatedPivot2DDistance(int i, int j)
    {
        return tooltipPositioners[i].projectedPosition - tooltipPositioners[j].projectedPosition;
    }

    private Vector3 AnchorToPivotVector(int elem)
    {
        if (tooltipPositioners[elem].positioner == null)
        {
            Debug.Log(tooltips[elem].name);
        }
        return tooltipPositioners[elem].positioner.pivotPosition - tooltipPositioners[elem].positioner.anchor.position;
    }

    public bool GetShowLabel()
    {
        return showLabels;
    }
}
