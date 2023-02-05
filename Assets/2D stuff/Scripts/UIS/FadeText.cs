using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(LerpColor(this.gameObject, 0, 255));
    }

    public IEnumerator LerpColor(GameObject objectToLerp, float firstValue, float lastValue)
    {
        float timeElapsed = 0;

        yield return new WaitForSeconds(1f);

        while (timeElapsed < 1)
        {

            objectToLerp.GetComponent<Image>().color = new Color(1,1,1,
                timeElapsed);

            timeElapsed += 0.05f;

            yield return new WaitForSeconds(0.1f);
        }

        objectToLerp.GetComponent<Image>().color = new Color(1, 1, 1,
               1);
    }
}
