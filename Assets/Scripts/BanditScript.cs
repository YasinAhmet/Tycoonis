using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BanditScript : MonoBehaviour
{
    public static BanditScript banditScript;

    public Slider slider;
    
    [Header("Bandit Authority")]
    public int BanditAuthority = 50;
    public int MaxBanditAuthority = 100;
    public int BanditAuthorityIncrease = 2;
    
    [Header("Bandit Hunt Features")]
    public int ForceToHunt = 1;
    public int MinAuthorityLossOnHunt = 2;

    // Start is called before the first frame update
    void Start()
    {
        banditScript = this;
    }

    public void TurnHappened()
    {
        if (BanditAuthority <= 0)
        {
            SceneManager.LoadScene("endgame");
        }
        
        if (BanditAuthority >= 100)
        {
            SceneManager.LoadScene("endgamelos");
        }
        
        if (BanditAuthority < MaxBanditAuthority)
        {
            if (TimeManager.timeManager.day > 10)
            {
                BanditAuthority += BanditAuthorityIncrease;
                slider.value = BanditAuthority;
            }
        }
        else
        {
            slider.value = 100;
        }
    }

    public void HuntHappened(int SentForceAmount)
    {
        soldierScript sc = UserStash.userstash.soldierScript;
        
        if (SentForceAmount >= ForceToHunt) {
            BanditAuthority -= SentForceAmount*5;
        }
    }
}
