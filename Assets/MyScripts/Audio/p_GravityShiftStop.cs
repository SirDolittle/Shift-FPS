using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_GravityShiftStop : MonoBehaviour
{
    bool gst_play;
    AudioSource gt_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        gt_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayShiftStopSound()
    {
        gt_AudioSource.Play();
    }
}
