using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController UiCTRL;
    public List<GameObject> uiTabs;

    private void Start()
    {
        UiCTRL = this;
    }

    public void UIClear()
    {
        foreach (GameObject gm in uiTabs)
        {
            gm.SetActive(false);
        }
        
    }
}
