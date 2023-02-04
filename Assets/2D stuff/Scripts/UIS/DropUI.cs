using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropUI : MonoBehaviour
{
    Dropdown drop;
    PlayerManager PM;
    (int, string) chosen;

    // Start is called before the first frame update
    void Start()
    {
         PM = FindObjectOfType<PlayerManager>();


        //Fetch the Dropdown GameObject
        drop = GetComponent<Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        drop.onValueChanged.AddListener(delegate {
            DropdownValueChanged(drop);
        });


        List<string> bois = new List<string>();

        foreach ((int,string) i in PM.collectedSecrets)
        {
            Debug.Log(i.Item2);
            bois.Add(i.Item2);
            //Initialise the Text to say the first value of the Dropdown
        }

        drop.ClearOptions();
        drop.AddOptions(bois);

    }
    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(Dropdown change)
    {
        Debug.Log(change.value);
        chosen = PM.collectedSecrets[change.value];
    }
}
