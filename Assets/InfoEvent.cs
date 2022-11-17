using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoEvent : MonoBehaviour
{
    [TextArea(5, 5)] public string text;

    public Text field;
    // Start is called before the first frame update
    public void DeathHappened(Soldier soldier)
    {
        text = text.Replace("[NAME]", soldier.name);
        text = text.Replace("[OLD]", soldier.age.ToString());

        if (soldier.age < 25)
        {
            text = text.Replace("[SPECIAL]", "He was a young and honorable man.");  
        }
        else
        {
            text = text.Replace("[SPECIAL]", "He had a " + soldier.equipment.equipmentname + " on his hand before he died.");  
        }

        field.text = text;
    }

    public void destroyInfo()
    {
        Destroy(this.gameObject);
    }
}
