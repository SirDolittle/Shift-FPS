using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    AudioSource a_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        a_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayAmmoSound()
    {
        a_AudioSource.Play();
    }
}
