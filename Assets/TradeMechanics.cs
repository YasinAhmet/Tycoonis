using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TradeMechanics : MonoBehaviour
{
    public List<float> prices = new List<float>();
    public float marketPrice_bfood = 1;
    public float marketPrice_bgood = 1;
    public float marketPrice_bgun = 5;
    public float marketPrice_bmat = 1;

    public float priceChaos = 0.02f;

    private void Start()
    {
        prices.Add(marketPrice_bfood);
        prices.Add(marketPrice_bgood);
        prices.Add(marketPrice_bgun);
        prices.Add(marketPrice_bmat);
    }

    public void TradeHappened()
    {
        UserStash.userstash.incomemanager.CheckEmptyStuff();
    }
    
    public void brTobg()
    {
        List<Resource> reses = new List<Resource>(UserStash.userstash.bResourceslist);
        if (UserStash.userstash.incomemanager.handleConsume((float)Math.Round(marketPrice_bgood/marketPrice_bmat, 3), reses))
        {
            UserStash.userstash.incomemanager.AddBGood(0);
            for (int i = 0; i < UserStash.userstash.bResourceslist.Count; i++)
            {
                if (reses.Count < i)
                {
                    return;
                } 
                UserStash.userstash.bResourceslist[i].amount = reses[i].amount;
            }
        }
        
        TradeHappened();
    }
    
    public void brTobf()
    {
        List<Resource> reses = new List<Resource>(UserStash.userstash.bResourceslist);
        if (UserStash.userstash.incomemanager.handleConsume((float)Math.Round(marketPrice_bfood/marketPrice_bmat, 3), reses))
        {
            UserStash.userstash.incomemanager.AddBFood(0);
            for (int i = 0; i < UserStash.userstash.bResourceslist.Count; i++)
            {
                UserStash.userstash.bResourceslist[i].amount = reses[i].amount;
            }
        }
        TradeHappened();
    }
    

    public void bgTobf()
    {
        List<Resource> reses = new List<Resource>(UserStash.userstash.bGoodslist);
        if (UserStash.userstash.incomemanager.handleConsume((float)Math.Round(marketPrice_bfood/marketPrice_bgood, 3), reses))
        {
            UserStash.userstash.incomemanager.AddBFood(0);
            for (int i = 0; i < UserStash.userstash.bGoodslist.Count; i++)
            {
                UserStash.userstash.bGoodslist[i].amount = reses[i].amount;
            }
        }
        TradeHappened();
    }
    
    public void bfTobg()
    {
        List<Resource> reses = new List<Resource>(UserStash.userstash.bFoodslist);
        if (UserStash.userstash.incomemanager.handleConsume((float)Math.Round(marketPrice_bgood/marketPrice_bfood, 3), reses))
        {
            UserStash.userstash.incomemanager.AddBGood(0);
            for (int i = 0; i < UserStash.userstash.bFoodslist.Count; i++)
            {
                UserStash.userstash.bFoodslist[i].amount = reses[i].amount;
            }
        }
        TradeHappened();
    }
    
    public void bgTobr()
    {
        List<Resource> reses = new List<Resource>(UserStash.userstash.bGoodslist);
        if (UserStash.userstash.incomemanager.handleConsume((float)Math.Round(marketPrice_bmat/marketPrice_bgood, 3), reses))
        {
            UserStash.userstash.incomemanager.AddBMat(0);
            for (int i = 0; i < UserStash.userstash.bGoodslist.Count; i++)
            {
                UserStash.userstash.bGoodslist[i].amount = reses[i].amount;
            }
        }
        TradeHappened();
    }
    
    public void baTobr()
    {
        List<Resource> reses = new List<Resource>(UserStash.userstash.bArmslist);
        if (UserStash.userstash.incomemanager.handleConsume((float)Math.Round(marketPrice_bmat/marketPrice_bgun, 3), reses))
        {
            UserStash.userstash.incomemanager.AddBMat(0);
            for (int i = 0; i < UserStash.userstash.bArmslist.Count; i++)
            {
                UserStash.userstash.bArmslist[i].amount = reses[i].amount;
            }
        }
        TradeHappened();
    }
    
    public void bfTobr()
    {
        List<Resource> reses = new List<Resource>(UserStash.userstash.bFoodslist);
        if (UserStash.userstash.incomemanager.handleConsume((float)Math.Round(marketPrice_bmat/marketPrice_bfood, 3), reses))
        {
            UserStash.userstash.incomemanager.AddBMat(0);
            for (int i = 0; i < UserStash.userstash.bFoodslist.Count; i++)
            {
                UserStash.userstash.bFoodslist[i].amount = reses[i].amount;
            }
        }
        TradeHappened();
    }

    public void turnHappened()
    {
        for (int l = 0; l < 2; l++)
        {
            for (int i = 0; i < prices.Count; i++)
            {
                float random = Random.Range(0f, 2f);

                if (random < 0.5f)
                {
                    prices[i] += priceChaos;
                }
                else if (random < 1f)
                {
                    prices[i] -= priceChaos;
                }
                
                prices[i] = (float)Math.Round(prices[i], 3, MidpointRounding.AwayFromZero);
            }
        }

        marketPrice_bfood = prices[0];
        marketPrice_bgood = prices[1];
        marketPrice_bgun = prices[2];
        marketPrice_bmat = prices[3];
    }
}
