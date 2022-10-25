using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmBuilding : MonoBehaviour
{
    public Tile farmTile;
    public int buildingCost = 100;
    public int buildingWork = 40;
    
    public void setFarmOnmouse(List<Vector3Int> filledLocs) {
        if (UserStash.userstash.getMoney() < buildingCost || UserStash.userstash.getWorkForce() < buildingWork) {
            return;
        }

        TileSelection.tilem.groundmap.SetTile(TileSelection.tilem.findLocMouse(), farmTile);
        Debug.Log("FARM LOC " + TileSelection.tilem.findLocMouse());
        UserStash.userstash.addMoney(-buildingCost, buildingWork);
        
        filledLocs.Add(TileSelection.tilem.findLocMouse());
    }
}
