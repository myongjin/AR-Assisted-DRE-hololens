using HoloToolkit.Unity.InputModule.Utilities.Interactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulationSetter : MonoBehaviour
{

    //public TwoHandManipulatable model;

    public TwoHandManipulatable[] systems;

    public TwoHandManipulatable[] boneOrgans;
    public TwoHandManipulatable[] urinaryOrgans;
    public TwoHandManipulatable[] reproOrgans;
    public TwoHandManipulatable[] muscleOrgans;
    public TwoHandManipulatable[] colonOrgans;

    public TwoHandManipulatable skin;

    private List<TwoHandManipulatable[]> organs = new List<TwoHandManipulatable[]>();

    public void Awake()
    {
        organs.Add(boneOrgans);
        organs.Add(urinaryOrgans);
        organs.Add(reproOrgans);
        organs.Add(muscleOrgans);
        organs.Add(colonOrgans);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetManipulateModel()
    {
        //model.enabled = true;

        foreach (TwoHandManipulatable go in systems)
        {
            go.enabled = false;
        }

        foreach (TwoHandManipulatable[] goArray in organs)
        {
            foreach (TwoHandManipulatable go in goArray)
            {
                go.enabled = false;
            }
        }

        skin.enabled = false;
    }

    public void SetManipulatSystem()
    {
        //model.enabled = false;

        foreach (TwoHandManipulatable go in systems)
        {
            go.enabled = true;
        }

        foreach (TwoHandManipulatable[] goArray in organs)
        {
            foreach (TwoHandManipulatable go in goArray)
            {
                go.gameObject.SetActive(true);
                go.enabled = false;
            }
        }

        skin.gameObject.SetActive(true);
        skin.enabled = true;
    }

    public void SetManipulatOrgan(int system)
    {
        //model.enabled = false;

        foreach (TwoHandManipulatable go in systems)
        {
            go.enabled = false;
        }

        for (int i = 0; i < organs.Count; i++)
        {
            foreach(TwoHandManipulatable go in organs[i])
            {
                go.gameObject.SetActive(i == system);
                go.enabled = (i == system);
            }
        }

        skin.gameObject.SetActive(false);
    }
}
