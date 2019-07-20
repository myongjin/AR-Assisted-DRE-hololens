using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentHelper : MonoBehaviour
{

    public static Vector3 GetCentroidPosition(Vector3[] positions)
    {
        if (positions.Length == 0) return Vector3.zero;
        Vector3 centroidPosition = Vector3.zero;
        for (int i = 0; i < positions.Length; i++)
        {
            centroidPosition += positions[i];
        }
        centroidPosition /= positions.Length;
        return centroidPosition;
    }

    public static float GetDistanceBetweenPoints(Vector3 a, Vector3 b)
    {
        return (a - b).magnitude;
    }
}
