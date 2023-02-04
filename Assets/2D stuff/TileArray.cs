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

    private Object[] tileSprites;


    [SerializeField] GameObject tileGO;

    private void Awake()
    {
        tiles = new Tile[fieldWidth-1, fieldHeight-1];
        tileSprites = Resources.LoadAll("LabyrinthPieces", typeof(Sprite));
    }

    private void Start()
    {
        initializeArray();
    }

    //Create array of tiles
    private void initializeArray()
    {
        for (int i = 0; i < fieldWidth; i++){

            for(int j = 0; j < fieldHeight; j++)
            {
                Tile tileBoi = new Tile(leftTilePos + new Vector3(tileSize * i, tileSize * j, 0));

                tiles[i, j] = tileBoi;
                Instantiate(tileGO, tileBoi.center, Quaternion.identity);
            }
        }

        tiles[(fieldWidth / 2) - 2, 0].OpenSide(Tile.Side.Up);
        tiles[(fieldWidth / 2) - 2, 0].OpenSide(Tile.Side.Down);
        UpdateImage(tiles[(fieldWidth / 2) - 2, 0]);
    }

    //Randomly open the paths in the array


    #region Update tile visually
    public void UpdateImage(Tile tile)
    {
        Sprite newSprite;

        (bool, bool, bool, bool) imageVector = (tile.up, tile.right, tile.down, tile.left);
        switch (imageVector)
        {
            //All open
            case (true, true, true, true):

                break;

            #region Three open
            //Three open
            case (true, true, true, false):

                break;

            case (true, true, false, true):

                break;

            case (true, false, true, true):

                break;

            case (false, true, true, true):

                break;
            #endregion

            #region Two open
            //Two open

            case (true, true, false, false):

                break;


            case (true, false, true, false):

                break;

            case (true, false, false, true):

                break;

            case (false, true, true, false):

                break;

            case (false, true, false, true):

                break;


            case (false, false, true, true):

                break;

            #endregion

            #region One open
            // ONE OPEN

            case (true, false, false, false):
                
                break;


            case (false, true, false, false):

                break;

            case (false, false, true, false):

                break;

            case (false, false, false, true):

                break;
            #endregion

            //ZERO OPEN
            case (false, false, false, false):
                tile.UpdateSprite(tileSprites[0] as Sprite);
                break;
        }
    }
    #endregion
}
