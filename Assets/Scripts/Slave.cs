using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slave : MonoBehaviour
{
    public int moneyPaid = 0;
    public int avgPeriod = 1000;

    public int setPeriod;
    public void setSlaveData(int money)
    {
        moneyPaid = money;
        int rnd = Random.Range(300-moneyPaid, 900-moneyPaid);
        setPeriod = rnd + avgPeriod;
    }
}
