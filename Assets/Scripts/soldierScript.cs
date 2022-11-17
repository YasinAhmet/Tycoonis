using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class soldierScript : MonoBehaviour
{
    public List<string> names = new List<string>();
    public List<Soldier> soldiers = new List<Soldier>();
    
    public GameObject stash;
    
    public IncomeScript incomeScript;
    
    public int soldierAmount = 0;
    public Text soldiertext;

    public float formingGoodCost = 1.5f;
    public float formingArmCost = 1.5f;

    public float soldier_food_consume = 0.5f;

    [SerializeField] public int wageAmount;

    public void UPDText()
    {
        soldiertext.text = soldiertext.GetComponent<TextData>().firstText + soldierAmount;
    }

    public void AddSoldier(int amount, Equipment equipment)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject sldobj = new GameObject("Soldier");
            sldobj.transform.parent = stash.transform;

            Soldier sldscr = sldobj.AddComponent<Soldier>();
            sldscr.ChangeEquipment(equipment);
            sldscr.age = Random.Range(18, 40);
            sldscr.name = names[Random.Range(0, names.Count)];

            soldiers.Add(sldscr);
        }
    }

    public void TurnHappened()
    {
        UPDText();
        for (int i = 0; i < soldierAmount; i++)
        {
            UserStash.userstash.incomemanager.handleConsume(soldier_food_consume, new List<Resource>(UserStash.userstash.bFoodslist));
        }
    }

    public void recruitSoldiers()
    {
        if (incomeScript.handleConsume(formingGoodCost, new List<Resource>(UserStash.userstash.bGoodslist),
                formingArmCost, new List<Resource>(UserStash.userstash.bArmslist))) {
            AddSoldier(1, new Equipment());
        }
    }
}
