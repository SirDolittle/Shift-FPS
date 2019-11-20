using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDeathExplosion : MonoBehaviour
{
    AudioSource td_AudioSource;
    bool hasPlayed; 
    // Start is called before the first frame update
    void Start()
    {
        td_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayTurretDeathSound()
    {
        if (td_AudioSource.isPlaying == false && hasPlayed == false)
        {
            td_AudioSource.Play();
            hasPlayed = true; 
        }

    }

    public void StopTurretDeathSound()
    {
        td_AudioSource.Stop();
    }
}
