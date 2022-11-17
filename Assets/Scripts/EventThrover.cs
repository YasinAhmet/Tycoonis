using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventThrover : MonoBehaviour
{
    public static EventThrover eventThrover;
    
    public List<GameObject> positiveEventList = new List<GameObject>();
    public List<GameObject> negativeEventList = new List<GameObject>();

    public int positivemaxtimeToThrowEvent = 20;
    public int positivemaxtimeGot = 0;
    private int positiveeventcounter = 0;
    
    public int negativemaxtimeToThrowEvent = 10;
    public int negativemaxtimeGot = 0;
    private int negativeeventcounter = 0;

    public GameObject eventFRAME;

    public List<UpperEvent1> activeEvents = new List<UpperEvent1>();
    public bool eventsystemON = false;

    public int safeTimes = 10;
    // Start is called before the first frame update
    void Start()
    {
        eventThrover = this;
    }

    // Update is called once per frame
    public void TurnHappened()
    {
        foreach (UpperEvent1 v in activeEvents)
        {
            v.turnspastafterevent++;
            if (v.turnspastafterevent > 2 && v.endOption != null)
            {
                v.endOption.EndMethod();
            } else if (v.turnspastafterevent > 2)
            {
                
            }
        }
        
        if (!eventsystemON || TimeManager.timeManager.day < safeTimes)
        {
            return;
        }
        
        if (positivemaxtimeGot == 0)
        {
            positivemaxtimeGot = Random.Range(1,positivemaxtimeToThrowEvent);
        }
        
        if (negativemaxtimeGot == 0)
        {
            negativemaxtimeGot = Random.Range(1, negativemaxtimeToThrowEvent - BanditScript.banditScript.BanditAuthority);
        }
        
        positiveeventcounter++;
        negativeeventcounter++;
        
        if (negativeeventcounter >= negativemaxtimeGot)
        {
            negativeeventcounter = 0;
            negativemaxtimeGot = 0;

            TimeManager.timeManager.STOP();
            GameObject selectedEvent = negativeEventList[Random.Range(1, negativeEventList.Count)-1];
            activeEvents.Add(Instantiate(selectedEvent, eventFRAME.transform).GetComponent<UpperEvent1>());
        }
        
        if (positiveeventcounter >= positivemaxtimeGot)
        {
            positiveeventcounter = 0;
            positivemaxtimeGot = 0;

            GameObject selectedEvent = positiveEventList[Random.Range(1, positiveEventList.Count)-1];
            Instantiate(selectedEvent, eventFRAME.transform);
        }
    }

    public void ThrowEvent(GameObject _event)
    {
        Instantiate(_event, eventFRAME.transform);
    }
}
