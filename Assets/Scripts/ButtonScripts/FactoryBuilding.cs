using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBuilding : MonoBehaviour
{
    public GameObject factoryTile;
    public IncomeScript incomeScript;
    public int buildingCost_bmat = 5;


    public void BuildFactoryOnMouse(List<Vector3Int> filledLocs) {
        if (!incomeScript.consumeThingAble(buildingCost_bmat, new List<Resource>(UserStash.userstash.bResourceslist))) {
            return;
        }

        GameObject gm = Instantiate(factoryTile);
        gm.transform.position = TileSelection.tilem.groundmap.GetCellCenterWorld(TileSelection.tilem.findLocMouse());
        incomeScript.factories.Add(gm);
        incomeScript.consumeThing(buildingCost_bmat, new List<Resource>(UserStash.userstash.bResourceslist));
        
        filledLocs.Add(TileSelection.tilem.findLocMouse());
    }
}
