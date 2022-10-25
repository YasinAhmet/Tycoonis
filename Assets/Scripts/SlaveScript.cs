using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlaveScript : MonoBehaviour
{
    public IncomeScript incomeScript;
    public UserStash userstash;
    public int MaxWorkerAmount = 0;
    public int workerAmount = 0;

    public Text maxworkertext;
    public Text workertext;
    
    public int updateTime;
    private int updatetracker;

    public int slaveTime;
    private int slavetracker;

    public Text moneycheckZone;
    

    public List<Slave> slavewaitList = new List<Slave>();
    

    // Update is called once per frame
    void Update()
    {
        updatetracker++;
        slavetracker++;

        if (updatetracker >= updateTime)
        {
            CalculateWorkerStuff();
        }

        if (slavetracker >= slaveTime && slavewaitList.Count != 0)
        {
            slavetracker = 0;
            slavewaitList[0].setPeriod -= 1;

            if (slavewaitList[0].setPeriod <= 0) {
                Destroy(slavewaitList[0].gameObject);
                slavewaitList.Remove(slavewaitList[0]);
                workerAmount++;
            }
        }
    }

    public void addSlaveToWList()
    {
        int moneypaid = 0;
        if (moneycheckZone.text != "")
        {
            moneypaid = int.Parse(moneycheckZone.text);
            userstash.addMoney(-moneypaid, 0);
        }

        if (moneypaid < 10 || MaxWorkerAmount <= workerAmount+slavewaitList.Count)
        {
            return;
        }
        
        
        GameObject gm = new GameObject();
        gm.AddComponent<Slave>();
        Slave slave = gm.GetComponent<Slave>();

        slave.setSlaveData(moneypaid);
        slavewaitList.Add(slave);
    }

    public void CalculateWorkerStuff()
    {
        MaxWorkerAmount = incomeScript.incomeCollectors.Count*5;

        maxworkertext.text = maxworkertext.GetComponent<TextData>().firstText + MaxWorkerAmount;
        workertext.text = workertext.GetComponent<TextData>().firstText + workerAmount;
    }
}
