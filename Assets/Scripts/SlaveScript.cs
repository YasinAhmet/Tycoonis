using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlaveScript : MonoBehaviour
{
    public IncomeScript incomeScript;
    public UserStash userstash;
    public int MaxWorkerAmount = 0;

    public Text maxworkertext;
    public Text workertext;
    
    public int updateTime;
    private int updatetracker;
    
    public Text moneycheckZone;

    public List<Slave> slaveList = new List<Slave>();
    public List<Slave> slavewaitList = new List<Slave>();

    private void Start()
    {
        CalculateWorkerStuff();
    }

    public void SlaveC()
    {
        CalculateWorkerStuff();
        
        if (slavewaitList.Count == 0)
        {
            return;
        }
        slavewaitList[0].setPeriod -= 1;

        if (slavewaitList[0].setPeriod <= 0)
        {
            slavewaitList[0].waitingfordeployment = false;
            slaveList.Add(slavewaitList[0]);
            Destroy(slavewaitList[0].gameObject);
            slavewaitList.Remove(slavewaitList[0]);
        }
    }

    public void addSlaveToWList()
    {
        float goodpaid = 0;
        bool success = false;
        if (moneycheckZone.text != "")
        {
            goodpaid = float.Parse(moneycheckZone.text);
            success = userstash.incomemanager.consumeThingAble(goodpaid, new List<Resource>(userstash.bGoodslist));
        }

        
        if (goodpaid < 1 || MaxWorkerAmount <= slaveList.Count+slavewaitList.Count || !success)
        {
            return;
        }
        
        userstash.incomemanager.consumeThing(goodpaid,new List<Resource>(userstash.bGoodslist));
        GameObject gm = new GameObject();
        gm.AddComponent<Slave>();
        Slave slave = gm.GetComponent<Slave>();

        slave.setSlaveData(goodpaid*10);
        slavewaitList.Add(slave);
    }

    public void CalculateWorkerStuff()
    {
        MaxWorkerAmount = incomeScript.incomeCollectors.Count*5;

        maxworkertext.text = maxworkertext.GetComponent<TextData>().firstText + MaxWorkerAmount;
        workertext.text = workertext.GetComponent<TextData>().firstText + slaveList.Count;
    }
}
