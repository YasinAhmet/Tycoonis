using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperEvent1 : DefEvent
{
    public eventRequirement opt2requirement;
    public eventRequirement opt1requirement;
    public eventRequirement opt3requirement;
    public eventRequirement opt4requirement;
    
    void Start()
    {
        fix();
    }

    public void Option4()
    {
        if (opt4requirement.CheckAll(userStash))
        {
            opt4requirement.FinishREQ(userStash);
            EventDone();
        }
    }
    
    public void Option3()
    {
        if (opt3requirement.CheckAll(userStash))
        {
            opt3requirement.FinishREQ(userStash);
            EventDone();
        }
    }

    public void Option2()
    {
        if (opt2requirement.CheckAll(userStash))
        {
            opt2requirement.FinishREQ(userStash);
            EventDone();
        }
    }

    public void Option1()
    {
        opt1requirement.FinishREQ(userStash);
        EventDone();
    }

    public void EventDone()
    {
        Destroy(gameObject);
    }
}
