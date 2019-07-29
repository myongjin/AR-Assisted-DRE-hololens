using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceVisualiser : MonoBehaviour
{
    public TextMesh forceText;

    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float forceMax = 10;

    private float force;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        force = ForceProcessor.Instance.Force;
        forceText.text = force.ToString("F2");

        foregroundImage.fillAmount = force / forceMax;
    }
}
