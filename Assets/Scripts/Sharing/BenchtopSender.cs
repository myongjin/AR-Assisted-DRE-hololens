using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchtopSender : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CustomMessages.Instance.SendTransform(CustomMessages.TestMessageID.BenchtopTransform, transform.position, transform.rotation);
    }
}
