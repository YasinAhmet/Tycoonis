using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingManager : MonoBehaviour
{
    public string managingType = "null";
    public Tilemap groundmap;
    
    public HouseBuilding houseScript;
    public FarmBuilding farmScript;
    public FactoryBuilding factoryScript;
    
    public GameObject house_Warning;
    public GameObject farm_warning;
    public GameObject production_warning;

    public List<Vector3Int> filledLocs = new List<Vector3Int>();
    public void Update()
    {
        ActivationManager();

        if (!Input.anyKeyDown)
        {
            return;
        }

        if (!groundmap.HasTile(TileSelection.tilem.findLocMouse()))
        {
            return;
        }

        Debug.Log(groundmap.HasTile(TileSelection.tilem.findLocMouse()) + " " + TileSelection.tilem.findLocMouse());

        if (CheckLocFill(TileSelection.tilem.findLocMouse()))
        {
            return;
        }

        switch (managingType) 
        {
            case "house":
                houseScript.BuildHouseOnMouse(filledLocs);
                break;
            case "farm":
                farmScript.setFarmOnmouse(filledLocs);
                break;
            case "factory":
                factoryScript.BuildFactoryOnMouse(filledLocs);
                break;
        }
    }

    public void SetManagingType(String type)
    {
        managingType = type;
    }

    public bool CheckLocFill(Vector3Int vec3)
    {
        foreach (Vector3Int vec3int in filledLocs) {
            if (groundmap.GetCellCenterWorld(vec3int) == groundmap.GetCellCenterWorld(vec3))
            {
                return true;
            }
        }

        if (TileSelection.tilem.groundmap.GetTile(vec3) == farmScript.farmTile)
        {
            return true;
        }

        return false;
    }

    public void ActivationManager()
    {
        house_Warning.SetActive(false);
        farm_warning.SetActive(false);
        production_warning.SetActive(false);
        
        switch (managingType)
        {
            case "house":
                house_Warning.SetActive(true);
                break;
            case "farm":
                farm_warning.SetActive(true);
                break;
            case "factory":
                production_warning.SetActive(true);
                break;
        }
    }
}
