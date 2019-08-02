using UnityEngine;

public class BenchtopViewSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject pelvicAnatomy;
    [SerializeField]
    private GameObject benchtop;
    [SerializeField]
    private GameObject landmarks;
    [SerializeField]
    private Renderer skin;
    [SerializeField]
    private Material originalSkin;
    [SerializeField]
    private Material DRESkin;

    private Game game;
    private GameObject[] prostates;

    // Use this for initialization
    void Start()
    {
        prostates = GameObject.FindGameObjectsWithTag("Prostate");

        game = Game.Instance;

        game.OnModelViewChange += OnModelViewChange;
        game.OnProstateChange += OnProstateChange;

        game.Prostate = ProstateType.Normal;
        ShowSkin();

    }

    private void OnProstateChange(ProstateType prostate)
    {
        SetProstate(prostate);
    }

    private void OnModelViewChange(ModelView modelView)
    {
        Debug.Log(modelView);
        switch (modelView)
        {
            case ModelView.Skin:
                ShowSkin();
                break;
            case ModelView.Prostate:
                ShowProstate();
                break;
            case ModelView.Anatomy:
                ShowAnatomy();
                break;
        }
    }

    public void ShowSkin()
    {
        // show skin
        skin.material = originalSkin;

        // show benchtop
        // show landmark
        // disable pelvic anatomy
        SetVisibleBenchtop(true);

        // set prostate
        SetProstate(game.Prostate);
    }

    public void ShowProstate()
    {
        // show transparent skin
        skin.material = DRESkin;

        // show benchtop
        // show landmark
        // disable pelvic anatomy
        SetVisibleBenchtop(true);

        // set prostate
        SetProstate(game.Prostate);
    }

    public void ShowAnatomy()
    {
        // show transparent skin
        skin.material = DRESkin;

        // disable benchtop
        // disable landmark
        // show pelvic anatomy
        SetVisibleBenchtop(false);

        // set prostate
        SetProstate(game.Prostate);
    }

    private void SetVisibleBenchtop(bool showBenchtop)
    {
        // show benchtop
        // show landmark
        // disable pelvic anatomy
        benchtop.SetActive(showBenchtop);
        landmarks.SetActive(showBenchtop);
        pelvicAnatomy.SetActive(!showBenchtop);
    }

    private void SetProstate(ProstateType prostateType)
    {
        foreach (GameObject prostate in prostates)
        {
            foreach (Transform child in prostate.transform)
            {
                child.gameObject.SetActive(child.gameObject.name == prostateType.ToString());
                if (child.gameObject.name == "collision") child.gameObject.SetActive(true);
            }
        }
    }
}