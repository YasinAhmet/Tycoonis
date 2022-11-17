using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class IncomeScript : MonoBehaviour
{
    [Header("References")]
    public List<GameObject> incomeCollectors = new List<GameObject>();
    public List<GameObject> factories = new List<GameObject>();
    public GameObject textPREF;
    public List<FarmData> toBeInstantiated = new List<FarmData>();
    public GameObject EFECTSTORE;
    public List<FarmData> farmdatalist = new List<FarmData>();
    
    [Header("Other")]
    public float defaultincomespeed = 1;
    public int instantiatesp;
    public int instantiatelmtspd;
    public Tilemap tilemap;

    [Header("Military")]
    public float militarySupplyProductionPotential = 0.45f;
    public Text militarySupply;

    public float militaryPotentialUpgradeRate = 0.30f;
    public int ProductionCost = 1;
    public float costToUpgrade = 1.50f;

    public void DefenceSpendingIncrease()
    {
        if (handleConsume(costToUpgrade, new List<Resource>(UserStash.userstash.bArmslist)))
        {
            ProductionCost++;
            militarySupplyProductionPotential += militaryPotentialUpgradeRate;
            costToUpgrade *= 2;
        }
    }
    
    public void DefenceSpendingLower()
    {
        ProductionCost--;
        militarySupplyProductionPotential -= militaryPotentialUpgradeRate;
        costToUpgrade /= 2;
    }
    
    public void TurnHappened()
    {
        getIncome();
        CheckEmptyStuff();
    }
    void Update()
    {
        instantiatesp++;
        
        if (instantiatesp >= instantiatelmtspd)
        {
            if (toBeInstantiated.Count != 0)
            {
                GameObject text = Instantiate(textPREF, EFECTSTORE.transform);
                text.SetActive(true);
                text.GetComponent<Text>().text = "Income " + toBeInstantiated[0].revenue;
                toBeInstantiated.Remove(toBeInstantiated[0]);
            }

            instantiatesp = 0;
        }
    }
    
    public void getIncome()
    {
        foreach (var VARIABLE in factories)
        {
            Debug.Log("GUN");
            if (handleConsume(ProductionCost, new List<Resource>(UserStash.userstash.bResourceslist)))
            {
                AddArm(Random.Range(1f,2f), false);
                militarySupply.text = militarySupply.GetComponent<TextData>().firstText +
                                      UserStash.userstash.bArmslist.Count;

            }
        }
        
        foreach (GameObject building in incomeCollectors)
        {
            List<TileBase> adjacents = TileManagement.tileManagement.getAdjacentTiles(tilemap, building.transform);
            adjacents = TileManagement.tileManagement.getIncomeAdjacentTiles(adjacents);

            foreach (TileBase tile in adjacents)
            {
                foreach (FarmData farmdata in farmdatalist)
                {
                    foreach (TileBase farmtile in farmdata.farmtiles)
                    {
                        if (farmtile.Equals(tile))
                        {
                            if (UserStash.userstash.cultivablefarm <= 0)
                            {
                                continue;
                            }

                            bool result = WorkerCons(defaultincomespeed);
                            if (!result)
                            {
                                break;
                            }
                            
                            UserStash.userstash.cultivablefarm--;

                            float chancefactor = Random.Range(0.1f, 0.4f);
                            AddFarmGoodsWithCurrent(chancefactor);
                            
                                //toBeInstantiated.Add(farmdata);
                                break;
                        }
                    }
                }
                
            }
        }
    }

    public void AddBGood(float chancefactor)
    {
        BasicGoods bgood = new BasicGoods();
        bgood.amount = defaultincomespeed*(UserStash.userstash.farmingEffectiveness + chancefactor);
        bgood.priceAsLuxury = (UserStash.userstash.farmingEffectiveness + chancefactor)/100;
        bgood.goodIMG = UserStash.userstash.bgood;
        UserStash.userstash.bGoodslist.Add(bgood);
    }

    public void AddBFood(float chancefactor)
    {
        BasicFoods bfood = new BasicFoods();
        bfood.amount = defaultincomespeed*(UserStash.userstash.farmingEffectiveness + chancefactor);
        bfood.happinessRate = UserStash.userstash.farmingEffectiveness;
        bfood.priceAsLuxury = (UserStash.userstash.farmingEffectiveness + chancefactor)/100;
        bfood.goodIMG = UserStash.userstash.bfood;
        UserStash.userstash.bFoodslist.Add(bfood);
    }

    public void AddBMat(float chancefactor)
    { 
        BasicResources bmat = new BasicResources();
        bmat.amount = defaultincomespeed*(UserStash.userstash.farmingEffectiveness + chancefactor);
        bmat.priceAsLuxury = (UserStash.userstash.farmingEffectiveness + chancefactor)/100;
        bmat.goodIMG = UserStash.userstash.bResource;
        UserStash.userstash.bResourceslist.Add(bmat);
    }

    public void AddArm(float chancefactor, bool highquality)
    {
        BasicArms barm = new BasicArms();
        barm.amount = militarySupplyProductionPotential * chancefactor;
        barm.priceAsLuxury = chancefactor/100;
        barm.goodIMG = UserStash.userstash.barm;
        UserStash.userstash.bArmslist.Add(barm);
    }

    public void AddFarmGoodsWithCurrent(float chancefactor)
    {
        AddBFood(chancefactor);
        AddBGood(chancefactor);
    }

    public bool handleConsume(float consumeAmount, List<Resource> reflist)
    {
        
        if (consumeThingAble(consumeAmount, reflist))
        {
            consumeThing(consumeAmount, reflist);
            return true;
        }

        return false;
    }
    
    public bool handleConsume(float consumeAmount, List<Resource> reflist, float consumeAmount2, List<Resource> reflist2)
    {
        Debug.Log("CONS " + consumeAmount + " " + consumeAmount2);
        if (consumeThingAble(consumeAmount, reflist) && consumeThingAble(consumeAmount2, reflist2))
        {
            Debug.Log("FIRST");
            consumeThing(consumeAmount, reflist);
            Debug.Log("SEKUNDEN");
            consumeThing(consumeAmount2, reflist2);
            return true;
        }

        return false;
    }
    
    public void CheckEmptyStuff()
    {
        
        foreach (BasicGoods VAR in UserStash.userstash.bGoodslist.ToList())
        {
            VAR.amount = (float)Math.Round(VAR.amount, 3);
            if (VAR.amount <= 0)
            {
                UserStash.userstash.bGoodslist.Remove(VAR);
            }
        }
        
        foreach (BasicFoods VAR in UserStash.userstash.bFoodslist.ToList())
        {
            VAR.amount = (float)Math.Round(VAR.amount, 3);
            if (VAR.amount <= 0)
            {
                UserStash.userstash.bFoodslist.Remove(VAR);
            }
        }
        
        foreach (BasicResources VAR in UserStash.userstash.bResourceslist.ToList())
        {
            VAR.amount = (float)Math.Round(VAR.amount, 3);
            if (VAR.amount <= 0)
            {
                UserStash.userstash.bResourceslist.Remove(VAR);
            }
        }
        foreach (BasicArms VAR in UserStash.userstash.bArmslist.ToList())
        {
            VAR.amount = (float)Math.Round(VAR.amount, 3);
            if (VAR.amount <= 0)
            {
                UserStash.userstash.bArmslist.Remove(VAR);
            }
        }
    }

    public bool consumeThingAble(float consumeAmount, List<Resource> reflist)
    {
        float testconsume = consumeAmount;

        foreach (Resource res in reflist)
        {
            float tres = res.amount;
            while (true)
            {
                float ares = res.amount;
                tres -= testconsume;
                testconsume -= ares;

                if (tres < 0)
                {
                    break;
                }
                
                if (tres >= 0 && testconsume <= 0) ;
                {
                    return true;
                }
            }
        }


        return false;
    }

    public void consumeThing(float consumeAmount, List<Resource> reflist)
    {
        foreach (Resource res in reflist)
        {
            while (res.amount > 0)
            {
                float ares = res.amount;
                res.amount -= consumeAmount;
                consumeAmount -= ares;

                if (res.amount <= 0)
                {
                    break;
                }
                
                if (consumeAmount <= 0) ; {
                    return;
                }
            }
        }
    }
    public bool WorkerCons(float incomespeed)
    {
        float foodcons = 0.50f;
        float goodcons = 0.25f;

        foodcons = incomespeed * foodcons;
        goodcons = incomespeed * goodcons;
        
        if (handleConsume(UserStash.userstash.slavescript.slaveList.Count * foodcons,
                new List<Resource>(UserStash.userstash.bFoodslist),
                UserStash.userstash.slavescript.slaveList.Count * goodcons,
                new List<Resource>(UserStash.userstash.bGoodslist))) {
            return true;
        } else
        {
            
        }

        Debug.Log("notdone");
        return false;
        
    }
}
