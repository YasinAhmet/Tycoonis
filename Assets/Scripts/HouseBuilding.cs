using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HouseBuilding : MonoBehaviour
{
    public GameObject houseTile;
    public IncomeScript incomeScript;
    public int buildingCost = 100;
    public int buildingWork = 40;


    public void BuildHouseOnMouse(List<Vector3Int> filledLocs) {
        if (UserStash.userstash.getMoney() < buildingCost || UserStash.userstash.getWorkForce() < buildingWork) {
            return;
        }

        GameObject gm = Instantiate(houseTile);
        gm.transform.position = TileSelection.tilem.groundmap.GetCellCenterWorld(TileSelection.tilem.findLocMouse());
        Debug.Log("BUILDING LOC " + TileSelection.tilem.findLocMouse());
        incomeScript.incomeCollectors.Add(gm);
        UserStash.userstash.addMoney(-buildingCost, buildingWork);
        
        filledLocs.Add(TileSelection.tilem.findLocMouse());
    }
}
