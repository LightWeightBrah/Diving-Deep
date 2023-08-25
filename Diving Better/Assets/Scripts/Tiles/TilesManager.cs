using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesManager : MonoBehaviour
{
    [SerializeField] private List<TileData> tilesData;
    [SerializeField] private Tilemap tilemap;

    private Dictionary<Vector2Int, WorldTile> dataForTile = new Dictionary<Vector2Int, WorldTile>();

    private void Awake()
    {
        
    }

    private void InitializeTileData()
    {
        for (int y = 0; y < (tilemap.origin.y + tilemap.size.y); y++)
        {
            for(int x = 0; x < (tilemap.origin.x + tilemap.size.x); x++) 
            {
                TileBase tile = tilemap.GetTile(new Vector3Int(x, y, 0));
                if(tile  != null)
                {
                    for (int i = 0; i < tilesData.Count; i++)
                    {
                        for(int j = 0; j < tilesData[i].tileBases.Count; j++)
                        {
                            if (tile == tilesData[i].tileBases[j])
                                dataForTile.Add(new Vector2Int(x, y), new WorldTile(tilesData[i]));
                        }
                    }
                }
            }
        }


        //for all tiles
        //for all tiles
        //   for(tilesData)
        //      if(tile == tileData)
        //         add to dictionary at current tile position world tile

        //foreach (var tileData in tilesData)
        //{
        //    foreach (var tileBase in tileData.tileBases)
        //    {
        //        dataForTile.Add(tileBase, tileData);
        //    }
        //}
    }

    /*public TileData GetTileData(Vector2 tilePosition)
    {

    }*/
}
