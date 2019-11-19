using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    bool f_play;
    AudioSource f_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        f_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayFootStepsSound()
    {
        if (f_AudioSource.isPlaying == false)
        {
        f_AudioSource.Play();
        }
    }

    public void StopFootStepSound()
    {
        if (f_AudioSource.isPlaying == true)
        {
            f_AudioSource.Stop();
        }
    }
}
