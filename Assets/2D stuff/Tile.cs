using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector3 center;
    public bool up = false, right = false, down = false, left = false;

    public enum Side { Up, Right, Down, Left};

    public Dictionary<(bool, bool, bool, bool), Sprite> sprite;

    private Object[] tiles;

    //Basic constructor
    public Tile(Vector3 _center)
    {
        center = _center;
    }

    public Tile(bool _up, bool _right, bool _down, bool _left, Vector3 _center)
    {
        up = _up;
        right = _right;
        left = _left;
        down = _down;
        center = _center;
    }

    public void OpenSide(Side open)
    {
        switch (open)
        {
            case Side.Up:
                up = true;
                break;
            case Side.Right:
                right = true;
                break;
            case Side.Down:
                down = true;
                break;
            case Side.Left:
                left = true;
                break;
        }
    }
}
