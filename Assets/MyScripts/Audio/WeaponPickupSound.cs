using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupSound : MonoBehaviour
{
    AudioSource wp_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        wp_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayWPickSound()
    {
        wp_AudioSource.Play();
    }
}
