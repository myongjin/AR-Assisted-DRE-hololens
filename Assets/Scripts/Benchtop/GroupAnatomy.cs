using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

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

    private void Start()
    {
        anatomyExpandable = GameObject.FindGameObjectsWithTag("AnatomyAnimation");
        tooltips = GameObject.FindGameObjectsWithTag("ToolTip");
    }

    public void ShowNormalBenchtop()
    {
        skin.SetActive(true);
        coccyx.SetActive(true);

        SetVisibleDRE(true);

        SetVisibleAnatomy(false);

        skin.GetComponent<Renderer>().material = benchtopNormal;
        DRERectum.GetComponent<Renderer>().material = benchtopNormal;
        coccyx.GetComponent<Renderer>().material = benchtopNormal;

        ToggleTooltip(false);
    }

    public void ShowTransparentBenchtop()
    {
        skin.SetActive(true);
        coccyx.SetActive(true);

        SetVisibleDRE(true);

        SetVisibleAnatomy(false);

        skin.GetComponent<Renderer>().material = benchtopTransparent;
        DRERectum.GetComponent<Renderer>().material = benchtopTransparent;
        coccyx.GetComponent<Renderer>().material = benchtopTransparent;

        ToggleTooltip(false);
    }

    public void ShowTransparentAnatomy()
    {
        skin.SetActive(true);
        coccyx.SetActive(true);

        SetVisibleDRE(false);

        SetVisibleAnatomy(true);

        skin.GetComponent<Renderer>().material = benchtopTransparent;
        DRERectum.GetComponent<Renderer>().material = benchtopTransparent;
        coccyx.GetComponent<Renderer>().material = benchtopTransparent;


        ToggleTooltip(true);
    }

    public void ShowProstate(string name)
    {
        foreach (Transform child in DREProstates.transform)
        {
            GameObject p = child.gameObject;
            p.SetActive(p.name == name);

        }
        foreach (Transform child in realProstates.transform)
        {
            GameObject p = child.gameObject;
            p.SetActive(p.name == name);
        }
    }

    private void SetVisibleDRE(bool show)
    {
        //DRERectum.SetActive(show);
        DRERectum.GetComponent<MaterialSetter>().SetMaterialClear(!show);
        DREProstates.SetActive(show);
    }

    private void SetVisibleAnatomy(bool show)
    {
        //if (!show && GameState.Instance.ShowTutorial)
        //{
        //foreach (GameObject anatomy in anatomyExpandable)
        //{
        //    anatomy.GetComponent<ExpandedView>().MinmiseExpandView();
        //}


        //urinary.SetActive(show);
        //repro.SetActive(show);
        //muscle.SetActive(show);
        //realProstates.SetActive(show);
        //realRectum.SetActive(show);

        //} else
        //{
        //bone.SetActive(show);
        SetMaterialClear(bone, show);
        SetMaterialClear(urinary, show);
        SetMaterialClear(repro, show);
        SetMaterialClear(muscle, show);

        //realProstates.GetComponent<MaterialSetter>().SetMaterialClear(!show);
        realRectum.GetComponent<MaterialSetter>().SetMaterialClear(!show);

        //urinary.SetActive(show);
        //repro.SetActive(show);
        //muscle.SetActive(show);
        realProstates.SetActive(show);
        //realRectum.SetActive(show);
        //}
    }



    private void ToggleTooltip(bool active)
    {
        if (tooltips != null && tooltips[0] != null)
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

    private void SetMaterialClear(GameObject organ, bool show)
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

