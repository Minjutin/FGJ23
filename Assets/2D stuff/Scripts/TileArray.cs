using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileArray : MonoBehaviour
{
    public int fieldWidth { get; private set; } = 7;
    public int fieldHeight { get; private set; } = 6;

    Vector3 leftTilePos;
    public float tileSize;

    public GameObject[,] tileGOs { get; private set; }
    public Tile[,] tileScripts { get; private set; }


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

        StartCoroutine(OpenPath());
    }

    //Randomly open the paths in the array

    IEnumerator OpenPath()
    {
        List<(int, int)> newTiles = new List<(int, int)>();

        //Starting tile
        Tile editTile = tileScripts[fieldWidth/2, 0];

        editTile.EditOpen((1, 0, 1, 0));
        spriteUpdater.UpdateSprite(editTile);
        editTile.inited = true;

        newTiles.Add((fieldWidth / 2, 1));

        while (true)
        {
            yield return null;

            //If tiles is empty
            if (newTiles.Count < 1) 
                break;

            (int,int) i = newTiles[0];

            editTile = tileScripts[i.Item1, i.Item2];

            //If edit tile was already checked
            if (editTile.inited)
            {
                newTiles.RemoveAt(0);
                continue;
            }


            Tile otherTile; //Other tile

            #region Checkers

            //CHECK UP
            if (i.Item2 > 0)
            {
                otherTile = tileScripts[i.Item1, i.Item2 - 1];

                //If there is no tile, randomize
                if (!otherTile.inited)
                {
                    int isOpen = Random.Range(0,2);
                    editTile.up = isOpen;

                    if (editTile.up == 1)
                        newTiles.Add((i.Item1, i.Item2 - 1));
                }

                //If there is a tile, make it as
                else
                {
                    editTile.up = otherTile.down;
                }
            }


            //CHECK LEFT
            if (i.Item1 > 0)
            {
                otherTile = tileScripts[i.Item1 - 1, i.Item2];

                //If there is no tile, randomize
                if (!otherTile.inited)
                {
                    int isOpen = Random.Range(0, 2);
                    editTile.left = isOpen;

                    if (editTile.left == 1)
                        newTiles.Add((i.Item1 - 1, i.Item2));
                }

                //If there is a tile, make it as
                else
                {
                    editTile.left = otherTile.right;
                }
            }


            //CHECK RIGHT
            if (i.Item1 < fieldWidth-1)
            {
                otherTile = tileScripts[i.Item1+1, i.Item2];

                //If there is no tile, randomize
                if (!otherTile.inited)
                {
                    int isOpen = Random.Range(0, 2);
                    editTile.right = isOpen;

                    if (editTile.right == 1)
                        newTiles.Add((i.Item1 + 1, i.Item2));
                }

                //If there is a tile, make it as
                else
                {
                    editTile.right = otherTile.left;
                }
            }


            //CHECK DOWN
            if (i.Item2 < fieldHeight - 1)
            {
                otherTile = tileScripts[i.Item1, i.Item2 + 1];

                //If there is no tile, randomize
                if (!otherTile.inited)
                {
                    int isOpen = Random.Range(0, 2);
                    editTile.down = isOpen;

                    if (editTile.down == 1)
                        newTiles.Add((i.Item1, i.Item2 + 1));
                }

                //If there is a tile, make it as
                else
                {
                    editTile.down = otherTile.up;
                }
            }

            #endregion

            spriteUpdater.UpdateSprite(editTile);
            editTile.inited = true;
            newTiles.RemoveAt(0);
        }
    }

}
 

