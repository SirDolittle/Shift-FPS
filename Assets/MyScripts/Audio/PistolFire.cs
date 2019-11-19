using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolFire : MonoBehaviour
{
    AudioSource p_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        p_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayPistolSound()
    {
        p_AudioSource.Play();
    }
}
