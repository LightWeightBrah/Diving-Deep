using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class DestructableTilesManager : MonoBehaviour
{
    [SerializeField] private List<TileData> tilesData;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tilemap testingTilemap;
    [SerializeField] private Transform miningBlocksParent;

    private void Awake()
    {
        this.InitializeTileData();
    }

    /*public void DamageTile(Vector2Int cellPosition, float damage)
    {
        WorldTile worldTile = this.dataForTile[cellPosition];
        worldTile.Health -= damage;
        Debug.Log($"Health of tile {cellPosition} is: {dataForTile[cellPosition].Health}");
        Vector3Int tilePosition = new Vector3Int(cellPosition.x, cellPosition.y, 0);
        //this.tilemap.SetTileFlags(tilePosition, TileFlags.None);
        //this.tilemap.SetColor(tilePosition, Color.red);
        ChangeColor(tilePosition);
        if (worldTile.Health <= 0)
        {
            this.tilemap.SetTile(tilePosition, null);
            onTileDestroyed?.Invoke(worldTile.TileData.itemToDrop, worldTile.TileData.amountToDrop);
        }
        //this.tilemap.SetColor(tilePosition, Color.white);
    }*/

    /*async void ChangeColor(Vector3Int tilePosition)
    {
        this.testingTilemap.SetTileFlags(tilePosition, TileFlags.None);
        this.testingTilemap.SetColor(tilePosition, Color.red);
        await Task.Delay(1000);
        this.testingTilemap.SetColor(tilePosition, Color.white);
    }*/

    private void InitializeTileData()
    {
        for (int y = this.tilemap.origin.y; y < this.tilemap.origin.y + this.tilemap.size.y; y++)
        {
            for (int x = this.tilemap.origin.x; x < this.tilemap.origin.x + this.tilemap.size.x; x++)
            {
                this.SetTileData(y, x);
            }
        }
    }

    private void SetTileData(int y, int x)
    {
        TileBase tile = this.tilemap.GetTile(new Vector3Int(x, y, 0));
        if (tile == null)
            return;

        for (int i = 0; i < tilesData.Count; i++)
        {
            if (tile == tilesData[i].TileBase)
            {
                Vector3 spawnPoisiton = new Vector3(x + 0.5f, y + 0.5f, 0);
                Instantiate(tilesData[i].TilePrefab, spawnPoisiton, Quaternion.identity, miningBlocksParent);
                this.tilemap.SetTile(new Vector3Int(x, y, 0), null);
            }
        }
    }

}
