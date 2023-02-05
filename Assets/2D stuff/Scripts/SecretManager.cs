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
"secretly believes the teletubbies are real",
"eats toothpaste",
"never eats the vegetables they buy",
"had a phase where they were too passionate about Veggietales",
"can't count past 10",
"doesn't recycle anything",
"steals a can of tuna everytime they go to a store",
"doesn't ever wash their towels",
"hasn't changed their toothbrush in the past 7 years",
"believes vaccuums suck all the oxygen in rooms",
"believes all statues are actually alive",
"secretly prefers the Finnish dub of Digimon over the original",
"thinks dandelions have spiritual healing powers",
"is afraid of everyone named Anne",
"smashes plates when angry",
"favors their youngest child despite denying it",
"never attends their kid's football matches",
"pirates all their films",
"steals toilet paper rolls from public bathrooms",
"steals pages from library books",
"has commited a sin once, though they are very ashamed of it",
"never uses version control while participating in game jams",
"often takes selfies in front of the mirror, still hates being pictured by other people",
"has a peculiar interest in clowns",
"always votes 'yes' regardless of the issue",
"believes that the internet is a series of tubes",
"has ruined their vocabulary by saying 'it be like that' too much",
"is such a boring person they literally have no secrets",
"spends hours at a time browsing Google Maps",
"prefers to eat food way past it's edible state"};

    string[] tier2 = {"blew up their hearing aid in the microwave trying to 'dry it' when it got wet",
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
"roleplays as a hamster on Thursdays",
"plays D&D just to swoon orc girls",
"wants to smash Tank Evans from Surf's Up",
"is way too interested in Gloria from Madagascar",
"likes to sing 'Mask by Dream' in karaoke",
"spends all their money on revealing anime figurines",
"draws church boats in bibles",
"has a folder of over 1000 sad anime quotes",
"nominated themselves as a candidate on accident",
"collects cockroach shells",
"keeps wild rats as pets in their apartment's bathroom",
"lies in every political campaign",
"eats jam straight from the jar with their fingers",
"pirates all their games",
"licks every frog they see",
"licks dirty coins clean",
"has a collection of stolen traffic signs",
"turns traffic signs upside down during the night",
"has a stolen soda dispenser in their house",
"only showers once every three months",
"takes baths in dishwasher soap",
"carries vodka in their water bottle to official meetings and conferences",
"had a drunken threesome with a married couple",
"uses an egg timer as an alarm clock",
"had a childhood dream of growing up to be a substance abuser",
"likes being called nasty things in bed",
"has never acted upon their campaign promises",
"attempted programming once, very bad things followed",
"often lies about their contributions to collaborative projects",
"sniffs glue on a regular basis",
"spends most of their wage on crypto",
"posts feet pictures on an instagram page",
"spends 10 hours per day on Reddit with an anonymous account",
"consumes meat raw so they can go to the hospital",
"is mean to nurses just to boost their own ego",
"fakes getting vaccines",
"loves needles in all their forms",};

    string[] tier3 = { "paid 200 euros for a fake degree certificate, so they could show it to their parents",
"owns a very steamy body pillow of Twilight Sparkles.",
"catfishes people on dating apps to get money for in-game-currency on a kids game",
"pays for feet pictures on OnlyFriends",
"is dating their pet pigeon",
"has a secret podcast about best Family Guy fanfictions",
"searches Yoda on r34 at least twice a day",
"is mean to food service workers just to get spit into their meal",
"draws non-kid-friendly sonic art",
"is the man who first posted on reddit about 'Cbat by Hudson Mohawke'",
"prints out inflation pictures on the school printer",
"enjoys Fortnite",
"has at least 20 different streaming service subscriptions",
"Carmelita Fox was their furry awakening",
"buys every nsfw match three game on Steam",
"owns multiple copies of American Pie movies",
"'s favorite show is Big Mouth",
"secretly believes Shark Tale to be the best movie of all time",
"goes around their apartment naked with their curtains open, hoping neighbours see",
"hosts Satanic rituals every Sunday with a few friends from the White House of Helsinki",
"burns some rainforest every chance they get",
"likes to taste bar bathroom floors",
"knowingly spoils shows for people",
"is an active 4chan user",
"huffs paint thinner regularly",
"believes all Oblivion NPCs are sentient... and commits heinous acts",
"likes to upload malware onto governmental servers for no particular reason",
"enjoys being tickled to an alarming degree",
"has used every known illegal drug at least once, though still claims to not be an addict",
"has contributed to the socio-economic degredation of Virkkala",
"is building a Femboy Hooters to Tampere",
"actually didn't get past the first grade, though is still an elected politician",
"bought 7 Yawning Ape Boat Club NFTs",
"sells free Unity assets on the internet marketplaces",
"has faked owning multiple Guinness World Records (their mother is very proud)",};

    string[] tier4 = { "once went into the bathroom to throw up but ended up pooping all over the ground",
"knows that birds are actually spies",
"has a side hustle as a plumber and poops in every toilet, urinal and sink they install",
"often has very gay thoughts, despite supporting anti-gay legislature",
"has authorized several drone strikes against civilian infrastructure in Kouvola",
"knows the truth about the 'Orimattila Battle Royale' incident",
"is actually the Lord incarnate",
"knows all about the Bite of '87",
"hosts a discord server for Fortnite consipiracy theories",
"was there when Jesus was crucified",
"is the actual father of Jesus",
"once caused a major wildfire when attempting to exterminate a wasp nest",
"is aware of the fact that they are an NPC in a videogame",
"has numerous financial connections to the Ostrobothnian Mafia",
"uses AI to make artpieces and then posts them claiming they were not made by AI",
"killed three people with a sledgehammer in 1986",
"once ate a sleeping homeless person",
"would actually really like to live in Lohja",
"has ACTUALLY done your mom (yes 'you' in specific, I know where 'you' live)",
"is actually the former North Korean leader",};

    public (int,string) GetNewSecret()
    {
        int tier = 0;
        int tierHelp = Random.Range(0, 100);

        //Debug.Log(tierHelp);

        if (tierHelp < 35)
            tier = 1;
        else if (tierHelp < 70)
            tier = 2;
        else if (tierHelp < 93)
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
                //Debug.Log(tier + secret);
                return (tier, secret);
                
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

    public void ClearCollected()
    {
        collectedSecrets.Clear();
    }
}
