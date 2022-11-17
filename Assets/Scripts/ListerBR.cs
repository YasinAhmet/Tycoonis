using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListerBR : Lister
{
    void Update()
    {
        S(new List<Resource>(UserStash.userstash.bResourceslist), "Amount");
    }
}
