using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TileSelection : MonoBehaviour
{
    public static TileSelection tilem;
    public Tilemap groundmap;

    void Start()
    {
        tilem = this;
    }
    public Vector3Int findLocMouse()
    {
        Vector3Int var1 = groundmap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        var1.Set(var1.x,var1.y,0);
        return var1;
    }

    public TileBase getTileOnMouse(Tilemap map)
    {
        TileBase tile = map.GetTile(findLocMouse());
        return tile;
    }
}
