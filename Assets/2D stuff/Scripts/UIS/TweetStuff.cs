using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TweetStuff : MonoBehaviour
{

    [SerializeField] GameObject tweet, points, prevTweet;
    GameManager GM;
    string username = "@paivi";

    bool enabledIs = false;

    string previousMesage;

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

    string[] startMessages = {"Are you aware that ",
    "Can you believe that ",
    "HUGE NEWS! ",
    "Grand reveal: ",
    "HAHAHA did you know that ",
    "Lmaooo I heard that ",
    "Could you guess that ",
    "It's true! ",
    "I just learnt that ",
    "Little exposé: ",
    "Fun fact: ",
    "The 8-ball tells you: ",
    "A bird told me that " };

    void OnEnable()
    {
        if (!enabledIs)
        {
            availabeNames = new List<string>();

            foreach (string i in names)
            {
                availabeNames.Add(i);
            }
        }
        if (enabledIs)
        {
            prevTweet.GetComponent<TextMeshProUGUI>().text = previousMesage;
        }

        enabledIs = true;

        GM = FindObjectOfType<GameManager>();

        //Randomize user name
        int nameInt = Random.Range(0,availabeNames.Count);
        username = availabeNames[nameInt];
        availabeNames.RemoveAt(nameInt);

        //Randomize message
        int mesgID = Random.Range(0, startMessages.Length);
        string message = startMessages[mesgID]+username+" "+GM.SM.chosen.Item2;

        previousMesage = message;


        tweet.GetComponent<TextMeshProUGUI>().text = message;

        int tier = GM.SM.chosen.Item1;

        string pointMessage = "";

        switch (tier)
        {
            case 1:
                pointMessage = "Tier 1 secret:\nThat's it? That's not even a real secret!\n+2 points";
                break;
            case 2:
                pointMessage = "Tier 2 secret:\nAnd this person is in charge of our future?!\n+4 points";
                break;
            case 3:
                pointMessage = "Tier 3 secret:\nScandalous! This person is truly a monster!\n+6 points";
                break;
            case 4:
                pointMessage = "ULTRA SECRET!\nThey'll be immediately exiled from the White House of Helsinki!\n+8 points";
                break;
        }

        GM.AddPoints(tier);
        points.GetComponent<TextMeshProUGUI>().text = pointMessage;


    }
}
