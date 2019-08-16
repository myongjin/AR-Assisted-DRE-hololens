using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelvicAnatomyController : MonoBehaviour {

    [SerializeField]
    private Transform skin;

    private void Start()
    {
        if (gameObject.name != "PelvicAnatomy")
        {
            Debug.LogError("Please attach PelvicAnatomyController script to PelvicAnatomy gameObject");
        }
    }

    public void ResetChildPosition()
    {
        ResetGameObjectTransform(skin);
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("ToolTip")) continue;
            ResetGameObjectTransform(child);

            foreach (Transform childOfChild in child)
            {
                if (child.gameObject.CompareTag("ToolTip")) continue;
                ResetGameObjectTransform(childOfChild);
            }
        }
    }

    private void ResetGameObjectTransform(Transform t)
    {
        t.localPosition = Vector3.zero;
        t.localEulerAngles = Vector3.zero;
        t.localScale = Vector3.one;
    }

}
