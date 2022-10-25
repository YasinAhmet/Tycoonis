using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject panelLayer;

    // Start is called before the first frame update
    void Start()
    {
        panelLayer.SetActive(false);
    }

    public void OnButtonDown()
    {
        UIController.uiCTRL.UIClear();

        if (!panelLayer.activeSelf)
        {
            panelLayer.SetActive(true);
        } else if (panelLayer.activeSelf)
        {
            panelLayer.SetActive(false);
        }
    }
    
}
