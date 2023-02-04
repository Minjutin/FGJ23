using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMove : MonoBehaviour
{
    TileArray tileArray;
    [SerializeField] GameObject player;

    Tile cTile;

    // Start is called before the first frame update
    void Start()
    {
        tileArray = this.GetComponent<TileArray>();
        player = GameObject.Find("Player");  
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(0.5f);
        
        cTile = tileArray.tileScripts[tileArray.fieldWidth / 2, 0];
        player.transform.position = cTile.center;
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
