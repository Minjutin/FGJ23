using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TweetStuff : MonoBehaviour
{

    [SerializeField] GameObject tweet, points;
    GameManager GM;
    string username = "@paivi";

    void OnEnable()
    {
        GM = FindObjectOfType<GameManager>();

        string message = "Hello! Did you know that " + username + " " + GM.SM.chosen.Item2 + "??";

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
                pointMessage = "SUPER SECRET!\nThey'll be immediately exiled from the White House of Helsinki!";
                break;
        }
        points.GetComponent<TextMeshProUGUI>().text = pointMessage;
    }
}
