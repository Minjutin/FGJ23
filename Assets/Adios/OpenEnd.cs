using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OpenEnd : MonoBehaviour
{
    GameManager GM;
    [SerializeField] GameObject points;
    [SerializeField] GameObject win, lose;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }

    private void OnEnable()
    {
        GM = FindObjectOfType<GameManager>();

        //Update points
        points.GetComponent<TextMeshProUGUI>().text = "Final points: "+GM.points;

        //UPDATE PIC
        if (GM.points > 30)
        {
            GM.AP.PlayBrain();
            win.SetActive(true);
        }
        else
        {
            GM.AP.PlayMenu();
            lose.SetActive(true);
        }

    }
}
