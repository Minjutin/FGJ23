using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [SerializeField] AudioSource normal, brain, menu; 
    // Start is called before the first frame update
    public void PlayNormal()
    {
        brain.Pause();
        menu.Pause();
        normal.Play();
    }

    // Update is called once per frame
    public void PlayBrain()
    {
        normal.Pause();
        menu.Pause();
        brain.Play();
    }

    // Update is called once per frame
    public void PlayMenu()
    {
        brain.Pause();
        normal.Pause();
        menu.Play();

    }
}
