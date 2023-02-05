using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGamey : MonoBehaviour
{

    [SerializeField] GameObject cat;
    [SerializeField] GameObject house;
    [SerializeField] GameObject startButton;

    // Update is called once per frame
    public void StartGame()
    {
        startButton.SetActive(false);
        StartCoroutine(Startiee());
    }

    IEnumerator Startiee()
    {
        yield return BasicLerp(cat, cat.transform.position, house.transform.position+new Vector3(0,80f,0), 1f);
        SceneManager.LoadScene("MiljaScene", LoadSceneMode.Single);
    }

    public IEnumerator BasicLerp(GameObject objectToLerp, Vector3 start, Vector3 end, float lerpDuration)
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {

            objectToLerp.transform.position =
                Vector3.Lerp(start, end, timeElapsed / lerpDuration);


            timeElapsed += Time.deltaTime;

            yield return null;
        }
        objectToLerp.transform.position = end;
    }
}
