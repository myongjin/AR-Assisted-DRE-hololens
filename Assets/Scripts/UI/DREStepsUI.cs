using HoloToolkit.Examples.InteractiveElements;
using System.Collections.Generic;
using UnityEngine;

public class DREStepsUI : MonoBehaviour
{
    private GameManager game;
    private InteractiveSet interactiveSet;
    private List<InteractiveToggle> interactiveToggles;

    // Use this for initialization
    private void Start()
    {
        game = GameManager.Instance;
        game.OnDREStageChange += OnDREStageChange;

        interactiveSet = GetComponent<InteractiveSet>();
        interactiveToggles = interactiveSet.Interactives;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnDREStageChange(DREStage dreStage)
    {
        var setSelections = new List<int>();

        for (int i = 0; i < (int)dreStage; i++)
        {
            interactiveToggles[i].HasSelection = true;
        }

        for (int i = (int)dreStage; i < System.Enum.GetValues(typeof(DREStage)).Length - 1; i++)
        {
            interactiveToggles[i].HasSelection = false;
        }
    }
}
