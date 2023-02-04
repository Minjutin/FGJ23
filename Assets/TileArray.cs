using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileArray : MonoBehaviour
{
    [SerializeField] int  fieldWidth = 6;
    [SerializeField] int fieldHeight = 6;

    Vector3 leftTilePos;
    float tileSize;

    Tile[,] tiles;

    [SerializeField] GameObject tile;

    private void Awake()
    {
        tiles = new Tile[fieldWidth-1, fieldHeight-1];
    }

    //Create array of tiles
    private void initializeArray()
    {
        for (int i = 0; i < fieldWidth; i++){

            for(int j = 0; j < fieldHeight; j++)
            {
                Tile tileBoi = new Tile(leftTilePos + new Vector3(tileSize * i, tileSize * j, 0));

                tiles[i, j] = tileBoi;
            }
        }

        tiles[(fieldWidth / 2) - 2, 0].OpenSide(Tile.Side.Up);
        tiles[(fieldWidth / 2) - 2, 0].OpenSide(Tile.Side.Down);
    }

    //Randomly open the paths in the array
}
