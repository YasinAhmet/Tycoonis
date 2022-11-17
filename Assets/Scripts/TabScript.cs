using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabScript : MonoBehaviour
{
    public GameObject panelLayer;

    // Start is called before the first frame update
    void Start()
    {
        panelLayer.SetActive(false);
    }

    public void OnButtonDown()
    {
        if (Input.GetButtonDown("Jump"))
        {
            return;
        }
        
        if (!panelLayer.activeSelf)
        {
            panelLayer.SetActive(true);
        } else if (panelLayer.activeSelf)
        {
            panelLayer.SetActive(false);
        }
    }
    
}
