using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfAmmo : MonoBehaviour
{
    AudioSource na_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        na_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayNoAmmoSound()
    {
        na_AudioSource.Play();
    }
}
