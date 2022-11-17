using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Soldier : MonoBehaviour
{
    public Equipment equipment = new Equipment();
    public string name = "Place Holder";
    public int age = 1;
    
    private void Start()
    {
        List<string> names = UserStash.userstash.soldierScript.names; 
        
        age = Random.Range(18, 50);
        name = names[Random.Range(0, names.Count)];
    }

    public void ChangeEquipment(Equipment equipment)
    {
        this.equipment = equipment;
    }
}
