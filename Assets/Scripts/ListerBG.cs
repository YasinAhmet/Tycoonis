using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListerBG : Lister
{
    void Update()
    {
        S(new List<Resource>(UserStash.userstash.bGoodslist), "KG");
    }
    
    
}
