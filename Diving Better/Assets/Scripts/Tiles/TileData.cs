using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "new Tile Data", menuName = "Custom Tiles/TileData")]
public class TileData : ScriptableObject
{
    public List<TileBase> tileBases;
    public float maxHealth;
}
