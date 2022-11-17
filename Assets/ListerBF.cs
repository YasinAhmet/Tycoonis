using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListerBF : Lister
{
    void Update()
    {
        CheckEmptyStuff();
        S(new List<Resource>(UserStash.userstash.bFoodslist), "KG");
        
    }
    
    public void CheckEmptyStuff()
    {
        foreach (BasicFoods VAR in UserStash.userstash.bFoodslist.ToList())
        {
            if (!(VAR.amount > 0))
            {
                UserStash.userstash.bFoodslist.Remove(VAR);
            }
        }
    }
}
