using HoloToolkit.Examples.InteractiveElements;
using UnityEngine;

public class UISwitcher : MonoBehaviour
{
    public GameObject ErrorPanel;
    public GameObject TrainingPanel;
    public Interactive ReAlignButton; 

    private GameManager game;

    private bool showMenu = false;

    // Use this for initialization
    private void Start()
    {
        game = GameManager.Instance;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void ToggleMenuVisible()
    {
        showMenu = !showMenu;
        gameObject.SetActive(showMenu);
    }
}
