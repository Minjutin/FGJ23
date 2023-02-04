using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileArray : MonoBehaviour
{
    [SerializeField] int  fieldWidth = 7;
    [SerializeField] int fieldHeight = 6;

    Vector3 leftTilePos;
    public float tileSize;

    GameObject[,] tileGOs;
    Tile[,] tileScripts;


    [SerializeField] GameObject tileGO;

    [SerializeField] UpdateTileSprite spriteUpdater; 

    private void Awake()
    {
        //Create arrays
        tileGOs = new GameObject[fieldWidth, fieldHeight];
        tileScripts = new Tile[fieldWidth, fieldHeight];

        //Fetch sprites and size
        tileSize = 3 * tileGO.transform.localScale.x;

        //Other
        leftTilePos = this.transform.position;
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
                tileGO.name = "Tile [" + i + "," + j + "]";
                tileGOs[i, j] = 
                Instantiate(tileGO, leftTilePos + new Vector3(tileSize * i, -tileSize * j, 0), Quaternion.identity,this.transform) as GameObject;
                tileScripts[i, j] = tileGOs[i, j].GetComponent<Tile>();
            }
        }

        //Starting tile
        tileScripts[(fieldWidth / 2), 0].OpenSide(Tile.Side.Up);
        tileScripts[(fieldWidth / 2), 0].OpenSide(Tile.Side.Down);
        spriteUpdater.UpdateImage(tileScripts[(fieldWidth / 2), 0]);


    }

    //Randomly open the paths in the array


 
}
