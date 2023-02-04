using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTileSprite : MonoBehaviour
{


    private Object[] tileSprites;

    private void Awake()
    {
        tileSprites = Resources.LoadAll("LabyrinthPieces", typeof(Sprite));
    }

    public void UpdateImage(Tile tile)
    {
        Sprite newSprite;

        (bool, bool, bool, bool) imageVector = (tile.up, tile.right, tile.down, tile.left);
        switch (imageVector)
        {
            //All open
            case (true, true, true, true):
                tile.UpdateSprite(tileSprites[6] as Sprite);
                break;

            #region Three open
            //Three open
            case (true, true, true, false):
                tile.UpdateSprite(tileSprites[5] as Sprite);
                break;

            case (true, true, false, true):
                tile.UpdateSprite(tileSprites[5] as Sprite);
                break;

            case (true, false, true, true):
                tile.UpdateSprite(tileSprites[5] as Sprite);
                break;

            case (false, true, true, true):
                tile.UpdateSprite(tileSprites[5] as Sprite);
                break;
            #endregion

            #region Two open
            //Corner

            case (true, true, false, false):
                tile.UpdateSprite(tileSprites[4] as Sprite);
                break;

            case (true, false, false, true):
                tile.UpdateSprite(tileSprites[2] as Sprite);
                break;

            case (false, true, true, false):
                tile.UpdateSprite(tileSprites[2] as Sprite);
                break;

            case (false, false, true, true):
                tile.UpdateSprite(tileSprites[2] as Sprite);
                break;

            //Straight
            case (true, false, true, false):
                tile.UpdateSprite(tileSprites[3] as Sprite);
                break;

            case (false, true, false, true):
                tile.UpdateSprite(tileSprites[3] as Sprite);
                break;

            #endregion

            #region One open
            // ONE OPEN

            case (true, false, false, false):
                tile.UpdateSprite(tileSprites[1] as Sprite);
                break;


            case (false, true, false, false):
                tile.UpdateSprite(tileSprites[1] as Sprite);
                break;

            case (false, false, true, false):
                tile.UpdateSprite(tileSprites[1] as Sprite);
                break;

            case (false, false, false, true):
                tile.UpdateSprite(tileSprites[1] as Sprite);
                break;
            #endregion

            //ZERO OPEN
            case (false, false, false, false):
                tile.UpdateSprite(tileSprites[0] as Sprite);
                break;
        }
    }
}
