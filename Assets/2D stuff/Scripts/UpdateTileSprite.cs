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

    public void UpdateSprite(Tile tile)
    {
        (int, int, int, int) imageVector = (tile.up, tile.right, tile.down, tile.left);
        switch (imageVector)
        {
            //All open
            case (1, 1, 1, 1):
                tile.UpdateSprite(tileSprites[6] as Sprite);
                tile.Rotate(0f);
                break;

            #region Three open
            //Three open
            case (1, 1, 1, 0):
                tile.UpdateSprite(tileSprites[5] as Sprite);
                tile.Rotate(90f);
                break;

            case (1, 1, 0, 1):
                tile.UpdateSprite(tileSprites[5] as Sprite);
                tile.Rotate(0f);
                break;

            case (1, 0, 1, 1):
                tile.UpdateSprite(tileSprites[5] as Sprite);
                tile.Rotate(270f);
                break;

            case (0, 1, 1, 1):
                tile.UpdateSprite(tileSprites[5] as Sprite);
                tile.Rotate(180f);
                break;
            #endregion

            #region Two open
            //Corner

            case (1, 1, 0, 0):
                tile.UpdateSprite(tileSprites[4] as Sprite);
                tile.Rotate(0f);
                break;

            case (1, 0, 0, 1):
                tile.UpdateSprite(tileSprites[2] as Sprite);
                tile.Rotate(0f);
                break;

            case (0, 1, 1, 0):
                tile.UpdateSprite(tileSprites[2] as Sprite);
                tile.Rotate(180f);
                break;

            case (0, 0, 1, 1):
                tile.UpdateSprite(tileSprites[2] as Sprite);
                tile.Rotate(270f);
                break;

            //Straight
            case (1, 0, 1, 0):
                tile.UpdateSprite(tileSprites[3] as Sprite);
                tile.Rotate(0f);
                break;

            case (0, 1, 0, 1):
                tile.UpdateSprite(tileSprites[3] as Sprite);
                tile.Rotate(90f);
                break;

            #endregion

            #region One open
            // ONE OPEN

            case (1, 0, 0, 0):
                tile.UpdateSprite(tileSprites[1] as Sprite);
                tile.Rotate(0f);
                break;


            case (0, 1, 0, 0):
                tile.UpdateSprite(tileSprites[1] as Sprite);
                tile.Rotate(90f);
                break;

            case (0, 0, 1, 0):
                tile.UpdateSprite(tileSprites[1] as Sprite);
                tile.Rotate(180f);
                break;

            case (0, 0, 0, 1):
                tile.UpdateSprite(tileSprites[1] as Sprite);
                tile.Rotate(270f);
                break;
            #endregion

            //ZERO OPEN
            case (0, 0, 0, 0):
                tile.UpdateSprite(tileSprites[0] as Sprite);
                tile.Rotate(0f);
                break;
        }
    }
}
