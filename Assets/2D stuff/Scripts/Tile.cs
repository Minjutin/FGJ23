using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject graphics;
    
    public Vector3 center { get; private set; }

    public bool inited = false, hasSecret = false;

    public int up = 0, right = 0, down = 0, left = 0;

    public Dictionary<(int, int, int, int), Sprite> sprite;

    GameObject secret;

    //Basic constructor

    private void Awake()
    {
        up = 0;
        right = 0;
        left = 0;
        down = 0;
        inited = false;
        center = this.transform.position;
    }

    public void EditOpen((int,int,int,int) opens)
    {
        up = opens.Item1;
        right = opens.Item2;
        down = opens.Item3;
        left = opens.Item4;

        if(OpenCount() != 1)
        {
            removeSecret();
        }
    }

    public void UpdateSprite(Sprite newSprite)
    {
        graphics.GetComponent<SpriteRenderer>().sprite = newSprite;

        if (OpenCount() == 1)
        {
            addSecret();
        }
    }

    public void addSecret()
    {
        hasSecret = true;
        secret = Instantiate(FindObjectOfType<SecretManager>().secret, center, Quaternion.identity, this.transform) as GameObject;
    }

    public void removeSecret()
    {
        hasSecret = false;
        Destroy(secret);
    }

    public void Rotate(float rotation)
    {
        graphics.transform.rotation = Quaternion.Euler(0, 0, -rotation);

    }

    public int OpenCount()
    {
        return up + down + left + right;
    }
}
