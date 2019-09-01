using UnityEngine;

public class ModelAlignment : MonoBehaviour
{
    public bool useFinger = false;
    public Transform[] positionSensor;
    public Transform model;
    public Transform[] virtualLandmarks;

    private Vector3[] virtualLandmarkPositions;
    private Vector4[] refPoints;
    private Vector3[] realLandmarkPositions;

    KabschSolver solver = new KabschSolver();

    public GameObject landmarkInfoObject;
    public TextMesh landmarkInfoText;
    public TextMesh registerButtonText;
    public TextMesh currentLandmarkText;

    public BenchtopSharing benchtopSharing;

    public int LandmarkCount { get; private set; }

    // Use this for initialization
    void Start()
    {
        virtualLandmarkPositions = new Vector3[virtualLandmarks.Length];
        realLandmarkPositions = new Vector3[virtualLandmarks.Length];
        refPoints = new Vector4[virtualLandmarks.Length];
        LandmarkCount = 0;

        virtualLandmarkPositions = GetAllLandmarkPositions(virtualLandmarks);
    }

    // Update is called once per frame
    void Update()
    {
        if (landmarkInfoObject.activeSelf)
        {
            ShowLandmarkInfo();
        }
    }

    #region PUBLIC_METHOD

    public void RestartAlignment()
    {
        LandmarkCount = 0;
    }

    public void AlignWithFinger(bool withFinger)
    {
        useFinger = withFinger;
    }

    public void RegisterRealLandmark()
    {
        int sensorNumber = useFinger ? 0 : 1;
        Debug.Log("Register Landmark: " + LandmarkCount);
        Debug.Log("V: " + virtualLandmarkPositions[LandmarkCount].ToString("F2") + " R: " + positionSensor[sensorNumber].position.ToString("F2"));
        realLandmarkPositions[LandmarkCount++] = positionSensor[sensorNumber].position;
        LandmarkCount %= virtualLandmarks.Length;
    }

    public void AlignModel()
    {
        Debug.Log("Align Model");
        benchtopSharing.IsManipulated = true;
        virtualLandmarkPositions = GetAllLandmarkPositions(virtualLandmarks);

        for (int i = 0; i < virtualLandmarks.Length; i++)
        {
            refPoints[i] = new Vector4(realLandmarkPositions[i].x, realLandmarkPositions[i].y, realLandmarkPositions[i].z, 1);
        }

        Matrix4x4 kabschTranform = solver.SolveKabsch(virtualLandmarkPositions, refPoints);

        Vector3 beforeCentroid = AlignmentHelper.GetCentroidPosition(virtualLandmarkPositions);

        for (int i = 0; i < virtualLandmarks.Length; i++)
        {
            virtualLandmarkPositions[i] = kabschTranform.MultiplyPoint3x4(virtualLandmarkPositions[i]);
        }
        Vector3 afterCentroid = AlignmentHelper.GetCentroidPosition(virtualLandmarkPositions);

        // translate model
        model.position += afterCentroid - beforeCentroid;

        // rotate model
        Quaternion rotation = kabschTranform.GetQuaternion();
        model.RotateAroundPivot(afterCentroid, rotation);
    }

    public void SaveModelLocation()
    {
        PlayerPrefHelper.SaveBenchtopTransform(model.localPosition, model.localRotation);
    }

    public void LoadModelLocation()
    {
        benchtopSharing.IsManipulated = true;
        model.localPosition = PlayerPrefHelper.LoadBenchtopPosition();
        model.localRotation = PlayerPrefHelper.LoadBenchtopRotation();
    }

    #endregion

    #region PRIVATE_METHODS

    private Vector3[] GetAllLandmarkPositions(Transform[] landmarks)
    {
        Vector3[] positions = new Vector3[landmarks.Length];
        for (int i = 0; i < virtualLandmarks.Length; i++)
        {
            positions[i] = virtualLandmarks[i].position;
        }

        return positions;
    }

    private float GetModelError()
    {
        float error = 0f;

        for (int i = 0; i < virtualLandmarks.Length; i++)
        {
            error += AlignmentHelper.GetDistanceBetweenPoints(realLandmarkPositions[i], virtualLandmarkPositions[i]);
        }

        return error;
    }

    private void ShowLandmarkInfo()
    {
        virtualLandmarkPositions = GetAllLandmarkPositions(virtualLandmarks);

        registerButtonText.text = "REGISTER: " + (LandmarkCount + 1).ToString();
        currentLandmarkText.text = "Landmark: " + (LandmarkCount + 1).ToString();

        string landmarkInfoString = "";
        for (int i = 0; i < virtualLandmarks.Length; i++)
        {
            landmarkInfoString += (i + 1).ToString();
            landmarkInfoString += ": ";
            landmarkInfoString += (virtualLandmarkPositions[i] - realLandmarkPositions[i]).ToString("F4");
            //landmarkInfoString += AlignmentHelper.GetDistanceBetweenPoints(virtualLandmarkPositions[i], realLandmarkPositions[i]).ToString("F2");
            landmarkInfoString += " ";
            landmarkInfoString += realLandmarkPositions[i].ToString("F2");
            landmarkInfoString += "\n";
        }

        landmarkInfoText.text = landmarkInfoString;
    }

    #endregion

}
