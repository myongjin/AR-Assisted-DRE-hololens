using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelViewSelector : MonoBehaviour
{

	public void SelectModelView(int view)
    {
        Game.Instance.ModelView = (ModelView)view;
    }
}
