using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTile
{
    public WorldTile(TileData tileData)
    {
        this.tileData = tileData;
    }

    [SerializeField] private TileData tileData;
    [SerializeField] private float health;

}
