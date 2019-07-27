using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceVisualiser : MonoBehaviour
{
    public TextMesh forceText;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        forceText.text = ForceProcessor.Instance.Force.ToString("F2");

    }
}
