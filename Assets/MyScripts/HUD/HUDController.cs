﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text HealthIntDisplay;
    public Text AmmoIntDisplay;
    PlayerStats playerStats;
    WeaponController weaponController;


    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        weaponController = FindObjectOfType<WeaponController>();

    }

    // Update is called once per frame
    void Update()
    {
        HealthIntDisplay.text = playerStats.currentHealth.ToString();

        if (weaponController.isWeaponEquipped[0] == true)
        {
            AmmoIntDisplay.text = weaponController.currentAmmoAmounts[0].ToString();
        }
        else if (weaponController.isWeaponEquipped[1] == true)
        {
            AmmoIntDisplay.text = weaponController.currentAmmoAmounts[1].ToString();
        }
        else if (weaponController.isWeaponEquipped[2] == true)
        {
            AmmoIntDisplay.text = weaponController.currentAmmoAmounts[2].ToString();
        }
    }



}