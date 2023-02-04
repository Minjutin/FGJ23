using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMove : MonoBehaviour
{
    TileArray tileArray;
    [SerializeField] GameObject player;
    [SerializeField] GameObject chooseCanvas;

    string prevDir;
    int x, y;

    [SerializeField] Tile currentTile, nextTile;

    string key = "right";

    // Start is called before the first frame update
    void Start()
    {
        tileArray = this.GetComponent<TileArray>();
        player = GameObject.Find("Player");  
        StartCoroutine(Move());
    }

    private void Update()
    {
        
        //Check the latest direction
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            key = "left";
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            key = "right";
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            key = "down";
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            key = "up";
        }

        //Check if it's a dead end
        if (Input.GetKeyDown(KeyCode.Space) && currentTile.OpenCount()==1 && currentTile.hasSecret)
        {
            (int, string) newSecret = FindObjectOfType<SecretManager>().GetNewSecret();

            FindObjectOfType<SecretManager>().AddFoundSecret(newSecret);
            currentTile.removeSecret();
        }
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(0.5f);

        x = tileArray.fieldWidth / 2;
        y = 0;

        currentTile = tileArray.tileScripts[x, y];

        player.transform.position = currentTile.center;

        //Start plah plah
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            //Find the next.
            //Check first if there is a tile open in a direction of pressed key
            if(key != prevDir)
            {
                switch (key)
                {
                    case "up":
                        if(y>0 && currentTile.up == 1)
                        {
                            y--;
                            nextTile = tileArray.tileScripts[x, y];
                        }

                        //If start tile, go out and END
                        else if (x == tileArray.fieldWidth / 2 &&
                        y == 0)
                        {
                            yield return BasicLerp(player, currentTile.center, currentTile.center + new Vector3(0,8,0), 0.6f);

                            FindObjectOfType<GameManager>().OpenChoice();
                            yield break;
                        }

                        break;
                    case "right":
                        if (x < tileArray.fieldWidth-1 && currentTile.right == 1)
                        {
                            x++;
                            nextTile = tileArray.tileScripts[x, y];
                        }
                        break;
                    case "down":
                        if (y < tileArray.fieldHeight-1 && currentTile.down == 1)
                        {
                            y++;
                            nextTile = tileArray.tileScripts[x, y];
                        }
                        break;
                    case "left":
                        if (x > 0 && currentTile.left == 1)
                        {
                            x--;
                            nextTile = tileArray.tileScripts[x, y];
                        }
                        break;
                }
            }

            if (nextTile != null)
            {
                yield return BasicLerp(player, currentTile.center, nextTile.center, 0.4f);

                currentTile = nextTile;
            }

            nextTile = null;
        }

    }

    public IEnumerator BasicLerp(GameObject objectToLerp, Vector3 start, Vector3 end, float lerpDuration)
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {

            objectToLerp.transform.position = Vector3.Lerp(start, end, timeElapsed / lerpDuration);

            timeElapsed += Time.deltaTime;

            yield return null;
        }
        objectToLerp.transform.position = end;
    }
}
