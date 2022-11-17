using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListerBA : Lister
{

    // Update is called once per frame
    void Update()
    {
        S(new List<Resource>(UserStash.userstash.bArmslist), "Amount");
    }
}
