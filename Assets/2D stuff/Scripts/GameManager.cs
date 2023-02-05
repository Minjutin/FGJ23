using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject GAME3D, GAME2D, chooseCan, tweetCan, cam2D;
    public SecretManager SM;
    public AudioPlayer AP;

    public int points= 0;

    [SerializeField] GameObject timerGO;
    [SerializeField] GameObject pointsGO;

    int timer = 345;

    bool timeOn = true;

    private void Awake()
    {
        pointsGO.GetComponent<TextMeshProUGUI>().text = "Points " + 0;
        SM = FindObjectOfType<SecretManager>();
        AP = FindObjectOfType<AudioPlayer>();
        AP.PlayNormal();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    public void Open3D()
    {
        AP.PlayNormal();
        timeOn = true;
        SM.ClearCollected();
        GAME3D.SetActive(true);
        cam2D.SetActive(false);
        tweetCan.SetActive(false);
    }

    public IEnumerator Open2D(Collider other)
    {
        AP.PlayBrain();
        GAME2D.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(other.gameObject);
        cam2D.SetActive(true);
        GAME3D.SetActive(false);
    }

    public void OpenChoice()
    {
        if (SM.collectedSecrets.Count > 0)
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
        AP.PlayMenu();
        timeOn = false;
        tweetCan.SetActive(true);
        chooseCan.SetActive(false);
    }


    IEnumerator Timer()
    {
        while (true)
        {
            timerGO.GetComponent<TextMeshProUGUI>().text = "TIME LEFT: " +timer;
            yield return new WaitForSeconds(1f);

            if (timeOn)
                timer--;

            if(timer < 0)
            {
                //TODO END GAME
            }
        }

    }

    public void AddPoints(int tier)
    {
        points += tier * 2;
        pointsGO.GetComponent<TextMeshProUGUI>().text = "Points " + points;
    }

}
