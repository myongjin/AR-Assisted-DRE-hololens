//using System;
//using UnityEngine;

//public class LabelPositioner : MonoBehaviour
//{
//    [SerializeField]
//    private float timeStart = 1f;
//    [SerializeField]
//    private float timeLeft = 1f;
//    [SerializeField]
//    private float radius = 0.33f;
//    [SerializeField]
//    private float angle = 1;
//    [SerializeField]
//    private float horizontal = 0.14f;
//    [SerializeField]
//    private float vertical = 0.06f;
//    [SerializeField]
//    private int startingLimit = 20;

//    private GameObject[] tooltips;

//    private ToolTipPosition[] tooltipPositions;
//    private Plane plane;

//    private void Awake()
//    {
//        Debug.Log("Start LabelPositioner");
//        tooltips = GameObject.FindGameObjectsWithTag("ToolTip");
//        tooltipPositions = new ToolTipPosition[tooltips.Length];

//        GetAnchorAndPivot();

//        plane = new Plane(CameraPlane.Instance.Normal, CameraPlane.Instance.Centre.position);

//        GetNewPivotPosition();
//        UpdatePivotPosition();
//    }

//    private void GetAnchorAndPivot()
//    {
//        for (var i = 0; i < tooltips.Length; i++)
//        {
//            // Get the tooltip
//            tooltipPositions[i].Parent = tooltips[i];

//            // Get anchor and pivot for each tooltip
//            foreach (Transform child in tooltips[i].transform)
//            {
//                switch (child.gameObject.name)
//                {
//                    case "Anchor":
//                        tooltipPositions[i].Anchor = child;
//                        break;
//                    case "Pivot":
//                        tooltipPositions[i].Pivot = child;
//                        break;
//                }
//            }
//        }
//    }

//    private void Update()
//    {
//        plane = new Plane(CameraPlane.Instance.Normal, CameraPlane.Instance.Centre.position);

//        GetAngleBetweenEachPivot();

//        //string text = "";
//        //for (int i = 0; i < tooltipPositions.Length; i++)
//        //{
//        //    text += tooltipPositions[i].Parent.name + ": " + tooltipPositions[i].Angle + "\n";
//        //}
//        //Debug.Log(text);

//        //find whether it is occluded or not
//        var isOccluded = GetOcclusion();

//        if (isOccluded)
//        {
//            timeLeft -= Time.deltaTime;

//            if (timeLeft < 0)
//            {
//                // fix occlusion
//                FixOcclusion();

//                timeLeft = timeStart;
//            }
//        }

//        //// find whether it is occluded or not
//        //bool isOccluded = false;
//        //int count = 100;
//        //count--;
//        //for (var i = 0; i < tooltips.Length; i++)
//        //{
//        //    var isEachOccluded = false;
//        //    var offsetAngle = 0f;
//        //    var prev = (i - 1 + tooltips.Length) % tooltips.Length;
//        //    var next = (i + 1) % tooltips.Length;

//        //    var currentPrev2DDistance = Pivot2DDistance(i, prev);
//        //    var currentNext2DDistance = Pivot2DDistance(i, next);

//        //    if (Math.Abs(currentPrev2DDistance.x) < 0.14 && Math.Abs(currentPrev2DDistance.y) < 0.08)
//        //    {
//        //        // Occlude the previous one
//        //        offsetAngle -= angle;
//        //        isEachOccluded = true;
//        //    }

//        //    if (Math.Abs(currentNext2DDistance.x) < 0.14 && Math.Abs(currentNext2DDistance.y) < 0.08)
//        //    {
//        //        // Occlude the next one
//        //        offsetAngle += angle;
//        //        isEachOccluded = true;
//        //    }

//        //    isOccluded |= isEachOccluded;

//        //}

//        //if (isOccluded)
//        //{
//        //    timeLeft -= Time.deltaTime;

//        //    if (timeLeft < 0)
//        //    {
//        //        // Update pivot position
//        //        FixPivotPosition();
//        //        Debug.Log("Updated");
//        //        timeLeft = 5;
//        //    }
//        //}
//        //else
//        //{
//        //    timeLeft = 5;
//        //}
//    }

//    private void GetNewPivotPosition()
//    {
//        for (var i = 0; i < tooltips.Length; i++)
//        {
//            // project each anchor to the plane
//            tooltipPositions[i].ProjectedAnchor = plane.ClosestPointOnPlane(tooltipPositions[i].Anchor.position);

//            var centreToProjectedAnchor = tooltipPositions[i].ProjectedAnchor - CameraPlane.Instance.Centre.position;

//            // calculate the pivot position on the centre plane
//            tooltipPositions[i].RadialPivotPosition = CameraPlane.Instance.Centre.position + centreToProjectedAnchor.normalized * radius;

//            // create anchor plane
//            var anchorPlane = new Plane(CameraPlane.Instance.Normal, tooltipPositions[i].Anchor.position);

//            // project it back to anchor plane
//            tooltipPositions[i].RadialPivotPosition = anchorPlane.ClosestPointOnPlane(tooltipPositions[i].RadialPivotPosition);


//            tooltipPositions[i].CalculatedPivotPosition = tooltipPositions[i].RadialPivotPosition;
//        }
//    }

//    private void UpdatePivotPosition()
//    {
//        for (var i = 0; i < tooltips.Length; i++)
//        {
//            // update the position of the pivot
//            tooltipPositions[i].Pivot.position = tooltipPositions[i].CalculatedPivotPosition;
//        }
//    }

//    private void GetAngleBetweenEachPivot()
//    {
//        Quaternion rotation = Quaternion.FromToRotation(CameraPlane.Instance.Normal, Vector3.back);
//        Matrix4x4 m = Matrix4x4.Rotate(rotation);

//        for (var i = 0; i < tooltips.Length; i++)
//        {
//            // project each anchor to the plane
//            tooltipPositions[i].ProjectedPivot = plane.ClosestPointOnPlane(tooltipPositions[i].Pivot.position);

//            var centreToProjectedPivot = tooltipPositions[i].ProjectedPivot - CameraPlane.Instance.Centre.position;

//            // Calculate angle from the beginning centreToPivot
//            var angle =
//                Vector3.SignedAngle(tooltipPositions[0].ProjectedPivot - CameraPlane.Instance.Centre.position,
//                    centreToProjectedPivot, CameraPlane.Instance.Normal);
//            if (angle < 0)
//            {
//                angle = 360 + angle;
//            }

//            tooltipPositions[i].Angle = angle;
//            tooltipPositions[i].ProjectedPivot2D = m.MultiplyPoint3x4(tooltipPositions[i].ProjectedPivot);
//        }

//        // Re-arrange the angle
//        Array.Sort(tooltipPositions, (x, y) => x.Angle.CompareTo(y.Angle));
//    }

//    private bool GetOcclusion()
//    {
//        bool isOccluded = false;

//        for (var i = 0; i < tooltips.Length; i++)
//        {
//            var prev = (i - 1 + tooltips.Length) % tooltips.Length;
//            var next = (i + 1) % tooltips.Length;

//            var currentPrev2DDistance = Pivot2DDistance(i, prev);
//            var currentNext2DDistance = Pivot2DDistance(i, next);

//            tooltipPositions[i].isOccludedPrev = Math.Abs(currentPrev2DDistance.x) < horizontal && Math.Abs(currentPrev2DDistance.y) < vertical;
//            tooltipPositions[i].isOccludedNext = Math.Abs(currentNext2DDistance.x) < horizontal && Math.Abs(currentNext2DDistance.y) < vertical;

//            isOccluded |= (tooltipPositions[i].isOccludedPrev || tooltipPositions[i].isOccludedNext);
//        }

//        return isOccluded;
//    }

//    private Vector3 Pivot2DDistance(int i, int j)
//    {
//        return tooltipPositions[i].ProjectedPivot2D - tooltipPositions[j].ProjectedPivot2D;
//    }

//    private void FixOcclusion()
//    {
//        GetNewPivotPosition();
//        UpdatePivotPosition();
//        GetAngleBetweenEachPivot();
//        //if (!GetOcclusion()) return;
//        int limit = startingLimit;
//        while (!GetOcclusion() || limit > 0)
//        {
//            limit--;
//            GetAngleBetweenEachPivot();
//            for (var i = 0; i < tooltips.Length; i++)
//            {
//                var offsetAngle = 0f;
//                if (tooltipPositions[i].isOccludedPrev)
//                {
//                    offsetAngle += angle;
//                    //isOccluded = true;
//                }

//                if (tooltipPositions[i].isOccludedNext)
//                {
//                    offsetAngle -= angle;
//                    //isOccluded = true;
//                }

//                Quaternion pivotRotation = Quaternion.AngleAxis(offsetAngle, CameraPlane.Instance.Normal);
//                tooltipPositions[i].CalculatedPivotPosition = tooltipPositions[i].CalculatedPivotPosition.RotateAroundPivot(CameraPlane.Instance.Centre.position, pivotRotation);
//                tooltipPositions[i].Pivot.position = tooltipPositions[i].CalculatedPivotPosition;
//            }
//        }

//        //bool isOccluded = true;
//        //int count = 100;
//        //while (isOccluded && count > 0)
//        //{
//        //    isOccluded = false;
//        //    count--;
//        //    for (var i = 0; i < tooltips.Length; i++)
//        //    {
//        //        var offsetAngle = 0f;
//        //        if (tooltipPositions[i].isOccludedPrev)
//        //        {
//        //            offsetAngle -= angle;
//        //            isOccluded = true;
//        //        }

//        //        if (tooltipPositions[i].isOccludedNext)
//        //        {
//        //            offsetAngle += angle;
//        //            isOccluded = true;
//        //        }

//        //        Quaternion pivotRotation = Quaternion.AngleAxis(offsetAngle, CameraPlane.Instance.Normal);
//        //        tooltipPositions[i].CalculatedPivotPosition = tooltipPositions[i].CalculatedPivotPosition.RotateAroundPivot(CameraPlane.Instance.Centre.position, pivotRotation);
//        //        tooltipPositions[i].Pivot.position = tooltipPositions[i].CalculatedPivotPosition;
//        //    }

//        //}
//    }
//}
