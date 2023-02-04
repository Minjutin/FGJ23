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
        Tile editTile = tileScripts[(fieldWidth / 2), 0];
        editTile.EditOpen((1,0,1,0));
        spriteUpdater.UpdateImage(editTile);

        editTile = tileScripts[1, 0];
        editTile.EditOpen((1, 1, 0, 0));
        spriteUpdater.UpdateImage(editTile);

        editTile = tileScripts[1, 1];
        editTile.EditOpen((0, 1, 1, 0));
        spriteUpdater.UpdateImage(editTile);

        editTile = tileScripts[1, 2];
        editTile.EditOpen((0, 0, 1, 1));
        spriteUpdater.UpdateImage(editTile);

        editTile = tileScripts[1, 3];
        editTile.EditOpen((1, 0, 0, 1));
        spriteUpdater.UpdateImage(editTile);
    }

    //Randomly open the paths in the array


 
}
