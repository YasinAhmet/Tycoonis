using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStash : MonoBehaviour
{
    public static UserStash userstash; 
    
    [Header("Event Data")]
    public Color TextColor;

    public Sprite BackGroundSprite;
    
    [Header("Other")]
    [SerializeField]
    private int workforceLimit = 100;
    private int money = 100;
    private int workForce;
    public SlaveScript slavescript;
    public IncomeScript incomemanager;
    public soldierScript soldierScript;

    public int getMoney() {
        return money;
    }

    public void addMoney(int amount, int workforceloss)
    {
        money += amount;
        workForce -= workforceloss;
    }

    public int getWorkForce() {
        return workForce;
    }

    void Start()
    {
        userstash = this;
        money = 100;
        workForce = 50;
    }

    public void IncreaseWorkforce(int n)
    {
        workForce += n;
    }

    public void TurnHappened()
    {
        BanditScript.banditScript.TurnHappened();
        
        workForce += 5 + (slavescript.workerAmount*5);

        if(workForce >= workforceLimit) {
            workForce--;
        }
    }
}
