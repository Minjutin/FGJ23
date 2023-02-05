using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TweetStuff : MonoBehaviour
{

    [SerializeField] GameObject tweet, points;
    GameManager GM;
    string username = "@paivi";

    bool enabled = false;

    List<string> availabeNames;

    string[] names = {"@PaiviR",
    "@AngryFlavored",
    "@P4steB0y08",
    "@Pige0nSl4yer1988",
    "@SimoH79",
    "@Randomlollis123",
    "@SpeedyJesus",
    "@Minjutin",
    "@Rollious",
    "@PlumbR1ng",
    "@WildyW0lf2009",
    "@Bronyyyy84",
    "@M0r4ls",
    "@DommyMommyA",
    "@ValtterV4alk58",
    "@CiderD4ddy",
    "@S0C00LS0nic",
    "@sussyposter",
    "@Cl0wnussy",
    "@PersuMersu69",
    "@CatgirlFanatic02",
    "@Peppaflation",
    "@SaleN48" };


    void OnEnable()
    {
        if (!enabled)
        {
            availabeNames = new List<string>();

            foreach (string i in names)
            {
                availabeNames.Add(i);
            }
        }

        enabled = true;

        GM = FindObjectOfType<GameManager>();

        //Randomize user name
        int nameInt = Random.Range(0,availabeNames.Count);
        username = availabeNames[nameInt];
        availabeNames.RemoveAt(nameInt);

        //Randomize message
        int mesgID = Random.Range(0, 4);
        string message = "";
        switch (mesgID)
        {
            case 0:
                message = "Hello! Did you know that " + username + " " + GM.SM.chosen.Item2 + "??";
                break;
            case 1:
                message = "MISJFLSDKJFSD " + username + " " + GM.SM.chosen.Item2 + "!!";
                break;
            case 2:
                message = "MISJFLSDKJFSD " + username + " " + GM.SM.chosen.Item2 + "!!";
                break;
            case 3:
                message = "MISJFLSDKJFSD " + username + " " + GM.SM.chosen.Item2 + "!!";
                break;
        }


        tweet.GetComponent<TextMeshProUGUI>().text = message;

        int tier = GM.SM.chosen.Item1;

        string pointMessage = "";

        switch (tier)
        {
            case 1:
                pointMessage = "Tier 1 secret:\nThat's it? That's not even a real secret!";
                break;
            case 2:
                pointMessage = "Tier 2 secret:\nAnd this person is in charge of our future?!";
                break;
            case 3:
                pointMessage = "Tier 3 secret:\nScandalous! This person is truly a monster!";
                break;
            case 4:
                pointMessage = "ULTRA SECRET!\nThey'll be immediately exiled from the White House of Helsinki!";
                break;
        }
        points.GetComponent<TextMeshProUGUI>().text = pointMessage;
    }
}
