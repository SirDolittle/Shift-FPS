using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNotActiveSound : MonoBehaviour
{
    AudioSource w_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        w_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayNoWeaponSound()
    {
        w_AudioSource.Play();
    }
}
