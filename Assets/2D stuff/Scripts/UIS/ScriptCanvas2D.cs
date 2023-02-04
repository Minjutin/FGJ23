using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptCanvas2D : MonoBehaviour
{
    TextMeshProUGUI textUGUI;
    PlayerManager PM;

    void Start()
    {
        textUGUI = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        PM = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    public void EditText()
    {
        string newText = "";
        int many = 1;

        foreach((int, string) i in PM.collectedSecrets)
        {
            newText = newText + many + ". " + i.Item2 + "\n\n";
            many++;
        }

        textUGUI.text = newText;
    }
}
