using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingDoorSound : MonoBehaviour
{
    AudioSource cd_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        cd_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayCloseDoorSound()
    {
        if (cd_AudioSource.isPlaying == false)
        {
            cd_AudioSource.Play();
        }

    }
}
