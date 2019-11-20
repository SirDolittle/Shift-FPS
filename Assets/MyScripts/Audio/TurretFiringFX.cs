using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFiringFX : MonoBehaviour
{
    AudioSource tf_AudioSource; 
    // Start is called before the first frame update
    void Start()
    {
        tf_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayturFireSound()
    {
        if (tf_AudioSource.isPlaying == false)
        {
            tf_AudioSource.Play();
        }
        else
        {
            tf_AudioSource.Stop();
        }

    }

    public void StopFireSound()
    {
        tf_AudioSource.Stop(); 
    }
}
