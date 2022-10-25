using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class BanditScript : MonoBehaviour
{
    public static BanditScript banditScript;
    
    [Header("Bandit Authority")]
    public int BanditAuthority = 10;
    public int MaxBanditAuthority = 15;
    public int BanditAuthorityIncrease = 1;
    
    [Header("Bandit Hunt Features")]
    public int ForceToHunt = 5;
    public int MinAuthorityLossOnHunt = 2;

    // Start is called before the first frame update
    void Start()
    {
        banditScript = this;
    }

    public void TurnHappened()
    {
        if (BanditAuthority < MaxBanditAuthority)
        {
            if (Random.Range(1, 2) == 1)
            {
                BanditAuthority += BanditAuthorityIncrease;
            }
        }
    }

    public void HuntHappened(int SentForceAmount)
    {
        soldierScript sc = UserStash.userstash.soldierScript;
        
        if (SentForceAmount >= ForceToHunt) {
            sc.AddSoldier(-Random.Range(1,SentForceAmount));
            BanditAuthority -= (int)(SentForceAmount/0.5);
        }
    }
}
