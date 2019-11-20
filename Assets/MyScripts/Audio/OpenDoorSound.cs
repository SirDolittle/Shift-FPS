using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorSound : MonoBehaviour
{
    AudioSource od_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        od_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayOpenDoorSound()
    {
        if(od_AudioSource.isPlaying == false)
        {
            od_AudioSource.Play();
        }
        
    }
}
