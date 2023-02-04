using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileArray : MonoBehaviour
{
    [SerializeField] int  fieldWidth = 6;
    [SerializeField] int fieldHeight = 6;

    Tile[,] tiles;

    private void Awake()
    {
        tiles = new Tile[fieldWidth, fieldHeight];
    }

    //Create array of tiles
    private void initializeArray()
    {

    }
}
