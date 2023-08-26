using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTile
{
    public float Health { get => this.health; set => this.health = value; }
    public TileData TileData => this.tileData;

    [SerializeField] private TileData tileData;
    [SerializeField] private float health;

    public WorldTile(TileData tileData)
    {
        this.tileData = tileData;
        this.health = tileData.maxHealth;
    }
}
