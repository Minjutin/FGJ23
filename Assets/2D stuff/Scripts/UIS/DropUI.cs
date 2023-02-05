using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropUI : MonoBehaviour
{
    TMPro.TMP_Dropdown drop;
    SecretManager SM;
    (int, string) chosen;

    // Start is called before the first frame update
    void OnEnable()
    {
         SM = FindObjectOfType<SecretManager>();


        //Fetch the Dropdown GameObject
        drop = GetComponent<TMPro.TMP_Dropdown>();

        //Add listener for when the value of the Dropdown changes, to take action
        drop.onValueChanged.AddListener(delegate {
            DropdownValueChanged(drop);
        });

        List<string> bois = new List<string>();

        //Debug.Log(SM.collectedSecrets.Count);

        foreach ((int,string) i in SM.collectedSecrets)
        {
            bois.Add(i.Item2);
            //Initialise the Text to say the first value of the Dropdown
        }

        drop.ClearOptions();
        drop.AddOptions(bois);

        SM.chosen = SM.collectedSecrets[0];

    }
    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(TMPro.TMP_Dropdown change)
    {
        SM.chosen = SM.collectedSecrets[change.value];
    }

}
