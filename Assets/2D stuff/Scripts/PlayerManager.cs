using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public List<(int, string)> collectedSecrets;

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
