using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_GravityShiftStart : MonoBehaviour
{
    bool gs_play;
    AudioSource g_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        g_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayShiftStartSound()
    {
        g_AudioSource.Play();
    }
}
