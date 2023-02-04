using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector3 center;
    public bool up = false, right = false, down = false, left = false;

    public enum Side { Up, Right, Down, Left};

    public Dictionary<(bool, bool, bool, bool), Sprite> sprite;

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

    public void UpdateImage()
    {
        (bool, bool, bool, bool) imageVector = (up, right, down, left);
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

                break;
        }
    }
}
