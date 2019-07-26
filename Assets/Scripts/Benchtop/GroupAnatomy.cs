using UnityEngine;

public class GroupAnatomy : MonoBehaviour
{
    public GameObject bone;
    public GameObject urinary;
    public GameObject repro;
    public GameObject muscle;

    public GameObject realProstates;
    public GameObject DREProstates;
    public GameObject realRectum;
    public GameObject DRERectum;

    public GameObject skin;
    public GameObject coccyx;

    public Material benchtopNormal;
    public Material benchtopTransparent;

    private GameObject[] anatomyExpandable;
    private GameObject[] tooltips;

    private Renderer skinRenderer;
    private Renderer DRERectumRenderer;
    private Renderer coccyxRenderer;

    private MaterialSetter DRERectumMaterialSetter;
    private MaterialSetter realRectumMaterialSetter;

    private void Start()
    {
        anatomyExpandable = GameObject.FindGameObjectsWithTag("AnatomyAnimation");
        tooltips = GameObject.FindGameObjectsWithTag("ToolTip");

        skinRenderer = skin.GetComponent<Renderer>();
        DRERectumRenderer = DRERectum.GetComponent<Renderer>();
        coccyxRenderer = coccyx.GetComponent<Renderer>();

        DRERectumMaterialSetter = DRERectum.GetComponent<MaterialSetter>();
        realRectumMaterialSetter = realRectum.GetComponent<MaterialSetter>();
    }

    public void ShowNormalBenchtop()
    {
        SetBenchtopVisiblewithMaterial(true, benchtopNormal);
    }

    public void ShowTransparentBenchtop()
    {
        SetBenchtopVisiblewithMaterial(true, benchtopTransparent);
    }

    public void ShowTransparentAnatomy()
    {
        SetBenchtopVisiblewithMaterial(false, benchtopTransparent);
    }

    public void ShowProstate(string name)
    {
        foreach (Transform child in DREProstates.transform)
        {
            GameObject prostate = child.gameObject;
            prostate.SetActive(prostate.name == name);
        }
        foreach (Transform child in realProstates.transform)
        {
            GameObject prostate = child.gameObject;
            prostate.SetActive(prostate.name == name);
        }
    }

    private void SetBenchtopVisiblewithMaterial(bool isVisible, Material material)
    {
        SetVisibleDRE(isVisible);
        SetVisibleAnatomy(!isVisible);

        skinRenderer.material = material;
        DRERectumRenderer.material = material;
        coccyxRenderer.material = material;

        ToggleTooltip(!isVisible);
    }

    private void SetVisibleDRE(bool show)
    {
        DRERectumMaterialSetter.SetMaterialClear(!show);
        DREProstates.SetActive(show);
    }

    private void SetVisibleAnatomy(bool show)
    {
        SetChildrenVisibility(bone, show);
        SetChildrenVisibility(urinary, show);
        SetChildrenVisibility(repro, show);
        SetChildrenVisibility(muscle, show);
        realRectumMaterialSetter.SetMaterialClear(!show);
        realProstates.SetActive(show);
    }

    private void ToggleTooltip(bool active)
    {
        if (tooltips != null && tooltips.Length > 0)
        {
            foreach (GameObject tooltip in tooltips)
            {
                if (tooltip.activeSelf != active)
                {
                    tooltip.SetActive(active);
                }
            }
        }
        else
        {
            Debug.Log("No tooltips found");
        }
    }

    private void SetChildrenVisibility(GameObject organ, bool show)
    {
        foreach (Transform childOrgan in organ.transform)
        {
            if (childOrgan.gameObject.tag != "ToolTip")
            {
                childOrgan.gameObject.GetComponent<MaterialSetter>().SetMaterialClear(!show);
            }
        }
    }
}

