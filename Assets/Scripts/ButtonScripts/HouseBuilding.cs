using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HouseBuilding : MonoBehaviour
{
    public GameObject houseTile;
    public IncomeScript incomeScript;
    public int buildingCost_bmat = 5;


    public void BuildHouseOnMouse(List<Vector3Int> filledLocs) {
        if (!incomeScript.consumeThingAble(buildingCost_bmat, new List<Resource>(UserStash.userstash.bResourceslist))) {
            return;
        }
        

        GameObject gm = Instantiate(houseTile);
        gm.transform.position = TileSelection.tilem.groundmap.GetCellCenterWorld(TileSelection.tilem.findLocMouse());
        incomeScript.incomeCollectors.Add(gm);
        incomeScript.consumeThing(buildingCost_bmat, new List<Resource>(UserStash.userstash.bResourceslist));
        
        filledLocs.Add(TileSelection.tilem.findLocMouse());
    }
}
