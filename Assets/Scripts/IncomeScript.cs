using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

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
    private int incomespeed;
    private int instantiatesp;
    public int instantiatelmtspd;
    public Tilemap tilemap;

    [Header("Military")]
    public float militarySupplyAmount = 0;
    public float militarySupplyProductionPotential = 0.45f;
    public Text militarySupply;

    public float militaryPotentialUpgradeRate = 0.30f;
    public int ProductionCost = 1;
    public int costToUpgrade = 150;

    public void DefenceSpendingIncrease()
    {
        if (UserStash.userstash.getMoney() >= costToUpgrade)
        {
            ProductionCost++;
            militarySupplyProductionPotential += militaryPotentialUpgradeRate;
            UserStash.userstash.addMoney(-costToUpgrade, 0);
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
            militarySupplyAmount += militarySupplyProductionPotential;
            militarySupply.text = militarySupply.GetComponent<TextData>().firstText + militarySupplyAmount;
            
            UserStash.userstash.addMoney(-ProductionCost, 0);
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
                            if (UserStash.userstash.getWorkForce() <= 1) {
                                //TODO LOG NO WORKFORCE
                                return;
                            }
                            
                            UserStash.userstash.addMoney(farmdata.revenue, farmdata.workcost);
                            toBeInstantiated.Add(farmdata);
                            break;
                        }
                    }
                }
                
            }
        }
    }
}
