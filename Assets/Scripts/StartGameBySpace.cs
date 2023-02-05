using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBySpace : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) ||Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("MiljaScene", LoadSceneMode.Single);
        }
    }
}
