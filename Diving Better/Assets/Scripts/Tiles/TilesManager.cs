using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesManager : MonoBehaviour
{
    [SerializeField] private List<TileData> tilesData;
    [SerializeField] private Tilemap tilemap;

    private Dictionary<TileBase, TileData> dataForTile = new Dictionary<TileBase, TileData>();

    private void Awake()
    {
        
    }

    private void InitializeTileData()
    {
        foreach (var tileData in tilesData)
        {
            foreach (var tileBase in tileData.tileBases)
            {
                dataForTile.Add(tileBase, tileData);
            }
        }
    }

    /*public TileData GetTileData(Vector2 tilePosition)
    {

    }*/
}
