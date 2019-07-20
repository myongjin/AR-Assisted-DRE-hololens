using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSetter : MonoBehaviour {

    public Material transparentMaterial;
    private Material originalMaterial;

	// Use this for initialization
	void Start () {
        originalMaterial = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetMaterialClear(bool isClear)
    {
        if (isClear)
        {
            GetComponent<MeshRenderer>().material = transparentMaterial;
        }
        else
        {
            GetComponent<MeshRenderer>().material = originalMaterial;
        }
    }
}
