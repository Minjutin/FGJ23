using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject graphics;
    
    public Vector3 center { get; private set; }

    public bool up = false, right = false, down = false, left = false;

    public enum Side { Up, Right, Down, Left};

    public Dictionary<(bool, bool, bool, bool), Sprite> sprite;

    //Basic constructor

    private void Awake()
    {
        up = false;
        right = false;
        left = false;
        down = false;
        center = this.transform.position;
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

    public void UpdateSprite(Sprite newSprite)
    {
        graphics.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
