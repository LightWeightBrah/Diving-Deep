using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class DestructableTilesManager : MonoBehaviour
{
    [SerializeField] private List<TileData> tilesData;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private UnityEvent<Item, int> onTileDestroyed;

    private Dictionary<Vector2Int, WorldTile> dataForTile = new Dictionary<Vector2Int, WorldTile>();

    private void Awake()
    {
        this.InitializeTileData();
    }

    public void DamageTile(Vector2Int cellPosition, float damage)
    {
        WorldTile worldTile = this.dataForTile[cellPosition];
        worldTile.Health -= damage;
        Debug.Log($"Health of tile {cellPosition} is: {dataForTile[cellPosition].Health}");
        if (worldTile.Health <= 0)
        {
            this.tilemap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y, 0), null);
            onTileDestroyed?.Invoke(worldTile.TileData.itemToDrop, worldTile.TileData.amountToDrop);
        }
    }

    private void InitializeTileData()
    {
        for (int y = tilemap.origin.y; y < (tilemap.origin.y + tilemap.size.y); y++)
        {
            for(int x = tilemap.origin.x; x < (tilemap.origin.x + tilemap.size.x); x++)
            {
                this.SetTileData(y, x);
            }
        }
    }

    private void SetTileData(int y, int x)
    {
        TileBase tile = tilemap.GetTile(new Vector3Int(x, y, 0));
        if (tile != null)
        {
            for (int i = 0; i < tilesData.Count; i++)
            {
                if (tile == tilesData[i].tileBase)
                    dataForTile.Add(new Vector2Int(x, y), new WorldTile(tilesData[i]));
            }
        }
    }

}
