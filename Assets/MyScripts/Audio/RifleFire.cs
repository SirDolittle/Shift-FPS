using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleFire : MonoBehaviour
{
    AudioSource r_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
       r_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayRifleSound()
    {
        r_AudioSource.Play();
    }
}
