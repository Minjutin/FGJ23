using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHous : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.02f);
            this.transform.Rotate(new Vector3(0,0, -0.2f), Space.Self);
        }

    }
}
