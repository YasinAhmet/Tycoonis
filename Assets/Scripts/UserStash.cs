using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class UserStash : MonoBehaviour
{
    public static UserStash userstash; 
    
    [Header("Event Data")]
    public Color TextColor;

    public GameObject deathEvent;

    public Sprite BackGroundSprite;

    [Header("Gathering Effectiveness")]
    public float farmingEffectiveness = 1;
    public float achievingEffectiveness = 1;

    [Header("Own Resources")] 
    public List<BasicArms> bArmslist = new List<BasicArms>();
    public List<BasicGoods> bGoodslist = new List<BasicGoods>();
    public List<BasicResources> bResourceslist = new List<BasicResources>();
    public List<BasicFoods> bFoodslist = new List<BasicFoods>();
    public List<ComplexArms> cArmslist = new List<ComplexArms>();
    public List<LuxuryFoods> lFoodslist = new List<LuxuryFoods>();
    public List<LuxuryGoods> lGoodslist = new List<LuxuryGoods>();

    [Header("Default Sprites")] 
    public Sprite bgood;
    public Sprite bResource;
    public Sprite bfood;
    public Sprite barm;

    [Header("Other")] [SerializeField] public int cultivablefarm = 5;
    public SlaveScript slavescript;
    public IncomeScript incomemanager;
    public soldierScript soldierScript;
    public TradeMechanics trademechanics;

    void Start()
    {
        userstash = this;
    }

    public void TurnHappened()
    {
        slavescript.SlaveC();
        BanditScript.banditScript.TurnHappened();
        cultivablefarm = Mathf.FloorToInt(slavescript.slaveList.Count*Random.Range(1f,2f));
        
    }
}
