﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : MonoBehaviour
{
    PlayerStats playerStats;
    // Start is called before the first frame update
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player"))
        {
            playerStats.currentHealth -= 5;
            Destroy(gameObject);
        } else
        {
            StartCoroutine(DeleteKnife());
        }

    }

    IEnumerator DeleteKnife()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
