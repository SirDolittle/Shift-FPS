using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHealthNoise : MonoBehaviour
{
    bool h_play;
    AudioSource h_AudioSource; 
    // Start is called before the first frame update
    void Start()
    {
        h_AudioSource = GetComponent<AudioSource>(); 
    }

    public void PlayHealthSound()
    {
        h_AudioSource.Play(); 
    }
}
