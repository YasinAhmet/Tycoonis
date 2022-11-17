using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmBuilding : MonoBehaviour
{
    public Tile farmTile;
    public IncomeScript incomeScript; 
    public int buildingCost_bgood = 3;

    private void Start()
    {
        incomeScript = UserStash.userstash.incomemanager;
    }

    public void setFarmOnmouse(List<Vector3Int> filledLocs) {
        if (!incomeScript.consumeThingAble(buildingCost_bgood, new List<Resource>(UserStash.userstash.bGoodslist))) {
            return;
        }

        TileSelection.tilem.groundmap.SetTile(TileSelection.tilem.findLocMouse(), farmTile);
        incomeScript.consumeThing(buildingCost_bgood, new List<Resource>(UserStash.userstash.bGoodslist));
        
        filledLocs.Add(TileSelection.tilem.findLocMouse());
    }
}
