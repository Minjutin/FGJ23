using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptCanvas2D : MonoBehaviour
{
    TextMeshProUGUI textUGUI;
    SecretManager SM;

    void Start()
    {
        textUGUI = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        SM = FindObjectOfType<SecretManager>();
    }

    // Update is called once per frame
    public void EditText()
    {
        string newText = "";
        int many = 1;

        foreach((int, string) i in SM.collectedSecrets)
        {
            newText = newText + many + ". " + i.Item2 + "\n\n";
            many++;
        }

        textUGUI.text = newText;
    }
}
