using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class eventRequirement : MonoBehaviour
{
    public bool isEndOption = false;
    public GameObject deathEvent;

    public void EndMethod()
    {
        if (isEndOption)
        {
            Debug.Log("END");
            Application.Quit();
        }
    }

    [TextArea(5, 5)] public string additionalText = "";
    
    [Header("Losses")]
    public int SoldierLoss = 0;

    public float chanceToBeKilled = 0.5f;

    [Header("Resource Loss")] 
    public float BFood = 0;
    public float BGood = 0;
    public float BArm = 0;
    public float BMat = 0;

    [Header("Gainments")]
    public int EnemyWeaknessPUSH = 0;
    public int SoldierGain = 0;

    public GameObject reqPanel;
    
    public bool CheckSoldierREQ()
    {
        if (UserStash.userstash.soldierScript.soldiers.Count >= SoldierLoss)
        {
            return true;
        }

        return false;
    }
    
    public bool CheckFoodREQ()
    {
        if (BFood <= 0)
        {
            return true;
        }
        if (UserStash.userstash.incomemanager.consumeThingAble(BFood, new List<Resource>(UserStash.userstash.bFoodslist)))
        {
            Debug.Log("Event_Check_Food Success");
            return true;
        }

        return false;
    }
    
    public bool CheckMatREQ()
    {
        if (BMat <= 0)
        {
            return true;
        }
        if (UserStash.userstash.incomemanager.consumeThingAble(BMat, new List<Resource>(UserStash.userstash.bResourceslist)))
        {
            Debug.Log("Event_Check_MAT Success");
            return true;
        }

        return false;
    }
    
    public bool CheckArmREQ()
    {
        if (BArm <= 0)
        {
            return true;
        }
        if (UserStash.userstash.incomemanager.consumeThingAble(BArm, new List<Resource>(UserStash.userstash.bArmslist)))
        {
            Debug.Log("Event_Check_ARM Success");
            return true;
        }

        return false;
    }
    
    public bool CheckGoodREQ()
    {
        if (BGood <= 0)
        {
            return true;
        }
        Debug.Log("Event_Check_Good Going");
        if (UserStash.userstash.incomemanager.consumeThingAble(BGood, new List<Resource>(UserStash.userstash.bGoodslist)))
        {
            Debug.Log("Event_Check_Good Success");
            return true;
        }

        return false;
    }
    
    public bool CheckAllSupplyREQ()
    {
        if (CheckArmREQ() && CheckFoodREQ() && CheckGoodREQ() && CheckMatREQ())
        {
            return true;
        }

        return false;
    }

    public bool CheckAll()
    {
        if (CheckSoldierREQ() && CheckAllSupplyREQ())
        {
            return true;
        }

        return false;
    }

    public void doCasualties(int soldierTotal)
    {
        for (int i = 0; i < Math.Abs(soldierTotal); i++)
        {
            if (Random.Range(0f, 1f) < chanceToBeKilled)
            {
                List<Soldier> soldatlist = UserStash.userstash.soldierScript.soldiers;
                int soldiernumbertobekilled = Random.Range(0, soldatlist.Count-1);

                deathEvent = UserStash.userstash.deathEvent;
                GameObject de = Instantiate(deathEvent, EventThrover.eventThrover.eventFRAME.transform);
                de.GetComponent<InfoEvent>().DeathHappened(soldatlist[soldiernumbertobekilled]);
                
                Destroy(soldatlist[soldiernumbertobekilled].gameObject);
                soldatlist.Remove(soldatlist[soldiernumbertobekilled]);
            }
        }
    }

    public void FinishREQ()
    {
        int soldierTotal = SoldierGain - SoldierLoss;

        Debug.Log(soldierTotal);
        if (soldierTotal > 0)
        {
            Debug.Log("EVTRQ SOLDIER");
            UserStash.userstash.soldierScript.AddSoldier(soldierTotal, new Equipment());
            
        } else if (soldierTotal < 0)
        {
            doCasualties(soldierTotal);
        }

        IncomeScript incs = UserStash.userstash.incomemanager;

        incs.handleConsume(BGood, new List<Resource>(UserStash.userstash.bGoodslist));
        incs.handleConsume(BArm, new List<Resource>(UserStash.userstash.bArmslist));
        incs.handleConsume(BFood, new List<Resource>(UserStash.userstash.bFoodslist));
        incs.handleConsume(BMat, new List<Resource>(UserStash.userstash.bResourceslist));
        
        BanditScript.banditScript.BanditAuthority -= EnemyWeaknessPUSH;
    }

    public string GetReqAsSTR()
    {
        string req = "";
        int soldierTotal = SoldierLoss + SoldierGain;

        if (additionalText != "")
        {
            req += "\n Additional Text: " + additionalText;
        }

        
        if (soldierTotal != 0) {
            req += "Maximum Soldier Effect: " + soldierTotal + "\n";
        }

        if (BFood != 0) {
            req += "Basic Food Effect: " + BFood + "\n";
        }

        if (BGood != 0)
        {
            req += "Basic Good Effect: " + BGood + "\n";
        }
        
        if (BMat != 0)
        {
            req += "Basic Resource Effect: " + BMat + "\n";
        }
        
        if (BArm != 0)
        {
            req += "Basic Arms Effect: " + BArm + "\n";
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
