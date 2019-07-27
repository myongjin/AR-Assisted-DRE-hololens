using UnityEngine;

public class AlignmentHelper : MonoBehaviour
{

    public static Vector3 GetCentroidPosition(Vector3[] positions)
    {
        if (positions.Length == 0) return Vector3.zero;
        var centroidPosition = Vector3.zero;
        foreach (var position in positions)
        {
            centroidPosition += position;
        }
        centroidPosition /= positions.Length;
        return centroidPosition;
    }

    public static float GetDistanceBetweenPoints(Vector3 a, Vector3 b)
    {
        return (a - b).magnitude;
    }
}
