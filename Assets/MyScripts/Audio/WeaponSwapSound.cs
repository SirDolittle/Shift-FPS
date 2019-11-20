using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwapSound : MonoBehaviour
{
    AudioSource ws_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        ws_AudioSource = GetComponent<AudioSource>();
    }

    public void PlaySwapSound()
    {
        ws_AudioSource.Play();
    }
}
