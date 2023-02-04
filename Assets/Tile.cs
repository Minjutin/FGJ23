using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int center;
    public bool up, right, down, left;

    private void Awake()
    {
        open = new bool[4];
    }


}
