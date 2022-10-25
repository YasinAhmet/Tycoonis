using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventRequirement : MonoBehaviour
{
    [Header("Losses")]
    public int SoldierLoss = 0;
    
    [Header("Neutral")]
    public int Money = 0;
    public int Workforce = 0;

    [Header("Gainments")]
    public int EnemyWeaknessPUSH = 0;
    public int SoldierGain = 0;

    public GameObject reqPanel;
    
    public bool CheckSoldierREQ(UserStash userStash)
    {
        if (userStash.soldierScript.soldierAmount >= SoldierLoss)
        {
            return true;
        }

        return false;
    }
    
    public bool CheckMoneyREQ(UserStash userStash)
    {
        if (userStash.getMoney() >= Money)
        {
            return true;
        }

        return false;
    }
    
    public bool CheckWorkREQ(UserStash userStash)
    {
        if (userStash.getWorkForce() >= Workforce)
        {
            return true;
        }

        return false;
    }

    public bool CheckAll(UserStash userStash)
    {
        if (CheckMoneyREQ(userStash) && CheckWorkREQ(userStash) && CheckSoldierREQ(userStash))
        {
            return true;
        }

        return false;
    }

    public void FinishREQ(UserStash userStash)
    {
        userStash.addMoney(Money, -Workforce);
        
        int soldierTotal = SoldierLoss + SoldierGain;

        userStash.soldierScript.AddSoldier(soldierTotal);

        BanditScript.banditScript.BanditAuthority -= EnemyWeaknessPUSH;
    }

    public string GetReqAsSTR()
    {
        string req = "";
        int soldierTotal = SoldierLoss + SoldierGain;

        if (SoldierLoss != 0 || SoldierGain != 0) {
            req += "Soldier Effect: " + soldierTotal + "\n";
        }

        if (Money != 0) {
            req += "Money Effect: " + Money + "\n";
        }

        if (Workforce != 0) {
            req += "Work Effect: " + Workforce + "\n";
        }

        if (EnemyWeaknessPUSH != 0) {
            req += "Hegemony Effect: " + EnemyWeaknessPUSH + "\n";
        }

        return req;
    }

    public void getReqPanel()
    {
        if (reqPanel.activeSelf == false)
        {
            reqPanel.SetActive(true);
            reqPanel.transform.Find("reqs").GetComponent<Text>().color = Color.green;
            reqPanel.transform.Find("reqs").GetComponent<Text>().text = GetReqAsSTR();
        }
    }

    public void removeReqPanel()
    {
        reqPanel.SetActive(false);
    }

}
