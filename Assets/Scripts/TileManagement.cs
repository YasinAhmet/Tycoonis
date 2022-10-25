using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManagement : MonoBehaviour
{
    public static TileManagement tileManagement;
    public List<TileBase> tiles = new List<TileBase>();
    public List<TileBase> incomeTiles = new List<TileBase>();
    public FarmData farm1;
    void Start()
    {
        tileManagement = this;
    }

    public List<TileBase> getAdjacentTiles(Tilemap tilemap, Transform position) {
        tiles = new List<TileBase>();

        Vector3Int targetPos = tilemap.WorldToCell(position.position);

        tiles.Add(tilemap.GetTile(targetPos + new Vector3Int(1, 0, 0)));
        tiles.Add(tilemap.GetTile(targetPos + new Vector3Int(-1, 0, 0)));
        tiles.Add(tilemap.GetTile(targetPos + new Vector3Int(0, 1, 0)));
        tiles.Add(tilemap.GetTile(targetPos + new Vector3Int(0, -1, 0)));
        tiles.Add(tilemap.GetTile(targetPos + new Vector3Int(1, 1, 0)));
        tiles.Add(tilemap.GetTile(targetPos + new Vector3Int(1, -1, 0)));
        tiles.Add(tilemap.GetTile(targetPos + new Vector3Int(-1, 1, 0)));
        tiles.Add(tilemap.GetTile(targetPos + new Vector3Int(-1, -1, 0)));

        Debug.Log(targetPos);

        return tiles;
    }

    public List<TileBase> getIncomeAdjacentTiles(List<TileBase> adjacenttiles) {
        incomeTiles = new List<TileBase>();
        foreach (TileBase tile in adjacenttiles)
        {
            foreach (TileBase tileb in farm1.farmtiles)
            {
                if (tileb.Equals(tile))
                {
                    incomeTiles.Add(tileb);
                }
            }
        }

        return incomeTiles;
    }
}
