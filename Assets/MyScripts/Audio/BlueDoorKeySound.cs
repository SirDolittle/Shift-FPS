using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoorKeySound : MonoBehaviour
{

    AudioSource bk_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        bk_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayKeySound()
    {
        if (bk_AudioSource.isPlaying == false)
        {
            bk_AudioSource.Play();
        }

    }
}
