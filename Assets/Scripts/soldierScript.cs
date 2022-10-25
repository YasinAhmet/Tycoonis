using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soldierScript : MonoBehaviour
{
    public IncomeScript incomeScript;
    
    public int soldierAmount = 0;
    public Text soldiertext;

    public int formingCost = 150;
    public int formingWork = 5;

    [SerializeField] public int wageAmount;

    public void UPDText()
    {
        soldiertext.text = soldiertext.GetComponent<TextData>().firstText + soldierAmount;
    }

    public void AddSoldier(int amount)
    {
        soldierAmount += amount;
    }

    public void TurnHappened()
    {
        UPDText();
        for (int i = 0; i < soldierAmount; i++)
        {
            UserStash.userstash.addMoney(-wageAmount, 0);
        }
    }

    public void recruitSoldiers()
    {
        if (UserStash.userstash.getMoney() < formingCost || UserStash.userstash.getWorkForce() < formingWork || incomeScript.militarySupplyAmount < 10) {
            return;
        }

        soldierAmount++;

        incomeScript.militarySupplyAmount -= 10;
        UserStash.userstash.addMoney(-formingCost, formingWork);
    }
}
