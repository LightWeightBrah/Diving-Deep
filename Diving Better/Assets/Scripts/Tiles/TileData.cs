using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "new Tile Data", menuName = "Custom Tiles/TileData")]
public class TileData : ScriptableObject
{
    public TileBase tileBase;
    public float maxHealth;
    public Item itemToDrop;
    public int amountToDrop;
}
