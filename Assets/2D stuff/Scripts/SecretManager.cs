using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretManager : MonoBehaviour
{

    public List<(int, string)> collectedSecrets;
    public GameObject tweetCanvas;
    public (int, string) chosen;

    public GameObject secret;

    string[] tier1 = { "enjoys taking pictures of pigeons a bit TOO much", };
    string[] tier2 = { "blew up their hearing aid in the microwave trying to 'dry it' when it got wet",
"stalks people through their window with binoculars",};
    string[] tier3 = { "paid 200 dollars for a fake degree certificate, so they could show it to their parents",
"owns a very steamy body pillow of Twilight Sparkles",
"catfishes people on dating apps to get money for in-game-currency on a kids game",};
    string[] tier4 = { "had a drunken threesome with a married couple. Went into the bathroom to throw up but ended up pooping all over the towel on the ground"};

    public (int,string) GetNewSecret()
    {
        int tier = 0;
        int tierHelp = Random.Range(0, 100);

        if (tierHelp < 35)
            tier = 1;
        else if (tierHelp < 68)
            tier = 2;
        else if (tierHelp < 85)
            tier = 3;
        else
            tier = 4;

        string secret;

        switch (tier)
        {
            case 1:
                secret = tier1[Random.Range(0, tier1.Length)];
                return (tier, secret);
             
            case 2:
                secret = tier2[Random.Range(0, tier2.Length)];
                return (tier, secret);
              
            case 3:
                secret = tier3[Random.Range(0, tier3.Length)];
                return (tier, secret);
                
            case 4:
                secret = tier4[Random.Range(0, tier4.Length)];
                return (tier,secret);
                
            default:
                return (0, "");
        }
    }

    private void Awake()
    {
        collectedSecrets = new List<(int, string)>();
    }

    public void AddFoundSecret((int, string) newSecret)
    {
        collectedSecrets.Add(newSecret);
        FindObjectOfType<ScriptCanvas2D>().EditText();
    }

    //Post iiit
    public void PostSecret()
    {
        tweetCanvas.SetActive(true);
        GameObject.Find("ChooseSecretCanvas").SetActive(false);
    }
}
