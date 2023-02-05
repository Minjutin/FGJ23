using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject GAME3D, GAME2D, chooseCan, tweetCan, cam2D;
    public SecretManager SM;

    private void Awake()
    {
        SM = FindObjectOfType<SecretManager>();
    }

    // Update is called once per frame
    public void Open3D()
    {
        SM.ClearCollected();
        GAME3D.SetActive(true);
        cam2D.SetActive(false);
        tweetCan.SetActive(false);
    }

    public IEnumerator Open2D(Collider other)
    {
        GAME2D.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(other.gameObject);
        cam2D.SetActive(true);
        GAME3D.SetActive(false);
    }

    public void OpenChoice()
    {
        if(SM.collectedSecrets.Count > 0)
        {
            chooseCan.SetActive(true);
        }
        else
        {
            Open3D();
        }
        GAME2D.SetActive(false);
    }

    public void OpenTweet()
    {
        tweetCan.SetActive(true);
        chooseCan.SetActive(false);
    }




}
