using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTurning : MonoBehaviour
{
    AudioSource et_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        et_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayturningSound()
    {
        if (et_AudioSource.isPlaying == false)
        {
            et_AudioSource.Play();
        }

    }
    public void StopTuringSound() 
    {
        if (et_AudioSource.isPlaying == true)
        {
            et_AudioSource.Stop();
        }

    }
}
