using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController uiCTRL;
    public List<GameObject> uiTabs;

    public void UIClear()
    {
        foreach (GameObject gm in uiTabs)
        {
            gm.SetActive(false);
        }
        
    }
}
