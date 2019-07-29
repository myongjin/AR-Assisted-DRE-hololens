using UnityEngine;

public class ToolTipPositionCalculator : MonoBehaviour
{
    public Vector3 normal;
    public float Angle;
    public Vector3 ProjectedPosition;

    public Transform Centre;
    public Transform Anchor;
    public Transform Pivot;

    private Plane plane;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            switch (child.gameObject.name)
            {
                case "Pivot":
                    Pivot = child;
                    break;
                case "Anchor":
                    Anchor = child;
                    break;
            }
        }
    }

    private void Update()
    {
        // create plane
        plane = new Plane(CameraPlane.Instance.Normal, Anchor.transform.position);
    }


}