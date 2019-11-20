using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosionSound : MonoBehaviour
{
    AudioSource be_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        be_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayBExplosionSound()
    {
        if (be_AudioSource.isPlaying == false)
        {
            be_AudioSource.Play();
        }
        else
        {
            be_AudioSource.Stop();
        }

    }

    public void StopBExplosionSound()
    {
        be_AudioSource.Stop();
    }
}
