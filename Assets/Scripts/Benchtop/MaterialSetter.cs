using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSetter : MonoBehaviour
{
    public Material transparentMaterial;

    private MeshRenderer meshRenderer;
    private Material originalMaterial;

    // Use this for initialization
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void SetMaterialClear(bool isClear)
    {
        if (isClear)
        {
            meshRenderer.material = transparentMaterial;
        }
        else
        {
            meshRenderer.material = originalMaterial;
        }
    }
}
