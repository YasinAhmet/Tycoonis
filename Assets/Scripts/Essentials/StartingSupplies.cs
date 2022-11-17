using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSupplies : MonoBehaviour
{  
    void Start()
    {
        UserStash.userstash.incomemanager.CheckEmptyStuff();
        UserStash.userstash.incomemanager.AddFarmGoodsWithCurrent(1);
        UserStash.userstash.incomemanager.AddFarmGoodsWithCurrent(1);
        
        UserStash.userstash.incomemanager.AddBMat(5);
        
        UserStash.userstash.slavescript.addSlaveToWList();
        UserStash.userstash.slavescript.SlaveC();
        UserStash.userstash.slavescript.SlaveC();
        UserStash.userstash.slavescript.SlaveC();
        UserStash.userstash.incomemanager.CheckEmptyStuff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
