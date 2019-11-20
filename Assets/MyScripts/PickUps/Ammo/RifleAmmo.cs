﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleAmmo : MonoBehaviour
{
    WeaponController weaponController;
    public int AmmoIncreaseAmmount;
    AmmoPickup ammoPickup;

    // Start is called before the first frame update
    void Start()
    {
        weaponController = FindObjectOfType<WeaponController>();
        ammoPickup = FindObjectOfType<AmmoPickup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            weaponController.currentAmmoAmounts[1] += AmmoIncreaseAmmount;
            Object.Destroy(this.gameObject);
            ammoPickup.PlayAmmoSound();
        }
        
        
    }
}
