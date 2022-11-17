using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerTabUpdate : MonoBehaviour
{
    public soldierScript soldierscript;

    public List<Text> textfields;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < textfields.Count; i++)
        {
            if (soldierscript.soldiers.Count <= i)
            {
                textfields[i].text = "Empty Slot";
                continue;
            }
            textfields[i].text = soldierscript.soldiers[i].name + " " + soldierscript.soldiers[i].age + " " +
                                 soldierscript.soldiers[i].equipment.equipmentname;
        }
    }
}
