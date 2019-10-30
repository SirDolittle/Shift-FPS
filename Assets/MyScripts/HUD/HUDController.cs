using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text HealthIntDisplay;
    public Text AmmoIntDisplay;
    public Image HealthBar;
    public Image WeaponDisplay;
    private float HealthConv; 
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
        UpdateHealthBar();
        UpdateAmmoAmount();

    }

    void UpdateAmmoAmount()
    {

        if (weaponController.isWeaponEquipped[0] == true)
        {
            AmmoIntDisplay.text = weaponController.currentAmmoAmounts[0].ToString();
            WeaponDisplay.sprite = weaponController.WeaponDisplayImage[0];


        }
        else if (weaponController.isWeaponEquipped[1] == true)
        {
            AmmoIntDisplay.text = weaponController.currentAmmoAmounts[1].ToString();
            WeaponDisplay.sprite = weaponController.WeaponDisplayImage[1];
        }
        else if (weaponController.isWeaponEquipped[2] == true)
        {
            AmmoIntDisplay.text = weaponController.currentAmmoAmounts[2].ToString();
            WeaponDisplay.sprite = weaponController.WeaponDisplayImage[2];
        }
    }

    void UpdateHealthBar()
    {
        HealthConv = playerStats.currentHealth / 100f;
        HealthBar.fillAmount = HealthConv;
        HealthIntDisplay.text = playerStats.currentHealth.ToString();
    }
}

