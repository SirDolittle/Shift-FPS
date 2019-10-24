﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int startingPlayerHealth = 100;
    public int currentHealth;
    private bool isPlayerDead;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingPlayerHealth; //sets starting health to full
    }

    // Update is called once per frame
    void Update()
    {

        PlayerDeath();
        

    }

    void PlayerDeath()
    {
        if (currentHealth <= 0)
        {
            Object.Destroy(GameObject.FindWithTag("Player").GetComponent<CharacterController>());
            Object.Destroy(GameObject.FindWithTag("Player").GetComponent<CapsuleCollider>());
        }
    }
        
    }


    //currentAmmoAmouts shows ammo for all weapons in the game