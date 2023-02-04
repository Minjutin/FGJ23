using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretManager : MonoBehaviour
{
    public GameObject secret;

    string[] tier1 = { "is ugly"};
    string[] tier2 = { "ate poop when 3 years old"};
    string[] tier3 = { "played fornite"};
    string[] tier4 = { "killed a man"};

    public (int,string) GetNewSecret()
    {
        int tier = Random.Range(1, 5);
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
}
