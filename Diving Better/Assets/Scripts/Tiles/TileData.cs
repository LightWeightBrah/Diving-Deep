using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "new Tile Data", menuName = "Custom Tiles/TileData")]
public class TileData : ScriptableObject
{
    public TileBase TileBase => this.tileBase;
    public MiningBlock TilePrefab => this.tilePrefab;
    public float MaxHealth => this.maxHealth;
    public Item ItemToDrop => this.itemToDrop;
    public int AmountToDrop => this.amountToDrop;

    [SerializeField] private TileBase tileBase;
    [SerializeField] private MiningBlock tilePrefab;
    [SerializeField] private float maxHealth;
    [SerializeField] private Item itemToDrop;
    [SerializeField] private int amountToDrop;
}
