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

        for (int i = 0; i < this.tilesData.Count; i++)
        {
            if (tile == this.tilesData[i].TileBase)
            {
                Vector3 spawnPoisiton = new Vector3(x + 0.5f, y + 0.5f, 0);
                Instantiate(this.tilesData[i].TilePrefab, spawnPoisiton, Quaternion.identity, this.miningBlocksParent);
                this.tilemap.SetTile(new Vector3Int(x, y, 0), null);
            }
        }
    }

}
