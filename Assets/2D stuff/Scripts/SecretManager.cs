using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretManager : MonoBehaviour
{

    public List<(int, string)> collectedSecrets;
    public GameObject tweetCanvas;
    public (int, string) chosen;

    public GameObject secret;

    string[] tier1 = { "enjoys taking pictures of pigeons a bit TOO much",
"has a huge fear of ants",
"believes that the earth is flat",
"pees in sinks",
"enjoys Nightcore versions of songs more than the normal versions",
"has never passed a math exam without cheating",
"uses plain ketchup as spaghetti sauce since they're too lazy to cook",
"enjoys the smell of rotten eggs",
"eats bellybutton dirt",
"likes to stare at the Sun",
"looks under the shirts of Barbiedolls",
"believes that birds are actually spies",
"licks bowling balls",
"steals doorknobs from grocery stores",
"fantasizes about putting a bee nest on their head",
"eats raw smoked tofu in bed",
"doesn't believe Finland really exists",
"thinks everyone can read their thoughts",
"puts mayo on their head because of the sensation",
"secretly believes the teletubbies are real" };
    string[] tier2 = { "blew up their hearing aid in the microwave trying to 'dry it' when it got wet",
"stalks people through their window with binoculars",
"has Rainbow Dash in a clear mason jar at home",
"eats sandbox sand when no one's looking",
"likes to consume paper of all kind",
"microwaves metallic forks when they're bored",
"runs a pyramid scheme that's all about ugly christams sweaters for cats",
"is actually just three kids on top of each other inside the robe",
"only uses public bathrooms because they like to have company",
"puts their hand in an ants nest sometimes because they like the tingle",
"used to eat bees as a kid",
"buys the combo of: Pringles, disposable gloves, sponges and lotion once a week",
"wears a Mickey Mouse costume to bed",
"steals strangers' socks in public changing rooms",
"uses AI to make artpieces and then posts them claiming they were not made by AI",
"roleplays as a hamster on Thursdays",
"plays D&D just to swoon orc girls",
"wants to smash Tank Evans from Surf's Up",
"is way too interested in Gloria from Madagascar",
"likes to sing 'Mask by Dream' in karaoke",
"spends all their money on revealing anime figurines"};
    string[] tier3 = { "paid 200 dollars for a fake degree certificate, so they could show it to their parents",
"owns a very steamy body pillow of Twilight Sparkles.",
"catfishes people on dating apps to get money for in-game-currency on a kids game",
"pays for feet pictures on OnlyFriends",
"is dating their pet pigeon",
"has a secret podcast about best Family Guy fanfictions",
"searches Yoda on r34 at least twice a day",
"is mean to food service workers just to get spit into their meal",
"draws non-kid-friendly sonic art",
"is the man who first posted on reddit about 'Cbat by Hudson Mohawke'",
"prints out inflation pictures on the school printer"};
    string[] tier4 = { "had a drunken threesome with a married couple",
"once went into the bathroom to throw up but ended up pooping all over the ground",
"knows that birds are actually spies",
"has a side hustle as a plumber and poops in every toilet, urinal and sink they install",};

    public (int,string) GetNewSecret()
    {
        int tier = 0;
        int tierHelp = Random.Range(0, 100);

        if (tierHelp < 35)
            tier = 1;
        else if (tierHelp < 68)
            tier = 2;
        else if (tierHelp < 95)
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
}
