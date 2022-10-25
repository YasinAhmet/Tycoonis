using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBuilding : MonoBehaviour
{
    public GameObject factoryTile;
    public IncomeScript incomeScript;
    public int buildingCost = 100;
    public int buildingWork = 40;


    public void BuildFactoryOnMouse(List<Vector3Int> filledLocs) {
        if (UserStash.userstash.getMoney() < buildingCost || UserStash.userstash.getWorkForce() < buildingWork) {
            return;
        }

        GameObject gm = Instantiate(factoryTile);
        gm.transform.position = TileSelection.tilem.groundmap.GetCellCenterWorld(TileSelection.tilem.findLocMouse());
        Debug.Log("FACTORY LOC " + TileSelection.tilem.findLocMouse());
        incomeScript.factories.Add(gm);
        UserStash.userstash.addMoney(-buildingCost, buildingWork);
        
        filledLocs.Add(TileSelection.tilem.findLocMouse());
    }
}
