using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGFire : MonoBehaviour
{
    AudioSource mg_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        mg_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayMGSound()
    {
        mg_AudioSource.Play();
    }
}
