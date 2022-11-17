using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperEvent1 : DefEvent
{
    public eventRequirement opt2requirement;
    public eventRequirement opt1requirement;
    public eventRequirement opt3requirement;
    public eventRequirement opt4requirement;

    public eventRequirement endOption;
    public eventRequirement defaultOption;
    
    void Start()
    {
        fix();
    }

    public void ExecuteDefault()
    {
        defaultOption.FinishREQ();
        EventDone();
    }

    public void Option4()
    {
        if (opt4requirement.CheckAll())
        {
            opt4requirement.FinishREQ();
            EventDone();
        }
    }
    
    public void Option3()
    {
        if (opt3requirement.CheckAll())
        {
            opt3requirement.FinishREQ();
            EventDone();
        }
    }

    public void Option2()
    {
        if (opt2requirement.CheckAll())
        {
            opt2requirement.FinishREQ();
            EventDone();
        }
    }

    public void Option1()
    {
        if (opt1requirement.CheckAll())
        {
            opt1requirement.FinishREQ();
            EventDone();
        }
    }

    public void EventDone()
    {
        EventThrover.eventThrover.activeEvents.Remove(this);
        Destroy(gameObject);
    }
}
