using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slave : MonoBehaviour
{
    public bool waitingfordeployment = true;
    public float moneyPaid = 0;
    public int avgPeriod = 5;
    public int setPeriod;

    public int WorkEfficiency = 1;
    public int foodsalary = 1;
    public void setSlaveData(float money)
    {
        moneyPaid = money;
        float rnd = Random.Range(1-moneyPaid/50, 5-moneyPaid/50);
        setPeriod = (int)(rnd + avgPeriod);
    }
}
