using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Sharing;
using HoloToolkit.Unity;
using UnityEngine;

public class ForceProcessor : Singleton<ForceProcessor>
{
    public float Force;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void ProcessForce(NetworkInMessage msg)
    {
        long userID = msg.ReadInt64();
        Force = CustomMessages.Instance.ReadFloat(msg);
    }
}
