using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class FarmData : ScriptableObject
{
    public TileBase[] farmtiles;
    public int revenue, workcost;

}
