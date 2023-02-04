using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject graphics;
    
    public Vector3 center { get; private set; }

    public int up = 0, right = 0, down = 0, left = 0;

    public Dictionary<(int, int, int, int), Sprite> sprite;

    //Basic constructor

    private void Awake()
    {
        up = 0;
        right = 0;
        left = 0;
        down = 0;
        center = this.transform.position;
    }

    public void EditOpen((int,int,int,int) opens)
    {
        up = opens.Item1;
        right = opens.Item2;
        down = opens.Item3;
        left = opens.Item4;
    }

    public void UpdateSprite(Sprite newSprite)
    {
        graphics.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void Rotate(float rotation)
    {
        graphics.transform.rotation = Quaternion.Euler(0, 0, -rotation);

    }
}
