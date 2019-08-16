using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemActiveMonitor : MonoBehaviour
{
    public LabelPositionAttacher attacher;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        attacher.SetActiveToolTips();
    }

    private void OnDisable()
    {
        attacher.SetActiveToolTips();
    }
}
