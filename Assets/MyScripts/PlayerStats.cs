using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int startingPlayerHealth = 100;
    public int currentHealth;

    public GameObject currentWEquipped;
    private GameObject levelStartWeapon;
    public GameObject playerWSlot;

    private bool isPlayerDead;
    private bool isWeaponChanging = false; 

    private WeaponController weaponController;

    public float[] currentAmmoAmounts;
    private bool[] isWeaponEquipped;

    // Start is called before the first frame update
    void Start()
    {
        isWeaponEquipped = new bool[3];
        currentHealth = startingPlayerHealth; //sets starting health to full
        weaponController = FindObjectOfType<WeaponController>();
        levelStartWeapon = weaponController.weapons[0];
        currentAmmoAmounts[0] = weaponController.weaponAmmoAmounts[0];
        currentAmmoAmounts[1] = weaponController.weaponAmmoAmounts[1];
        currentAmmoAmounts[2] = weaponController.weaponAmmoAmounts[2];
        StartingWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        EquipWeapon();

        

    }

    void StartingWeapon()
    {
        
        currentWEquipped = levelStartWeapon;
        currentWEquipped = Instantiate(currentWEquipped, playerWSlot.transform.position, Quaternion.identity) as GameObject;
        currentWEquipped.transform.parent = GameObject.FindWithTag("PlayerCamera").transform;

    }

    void CurrentCarryWeapons()
    {
        //stores all the weapons the player is currently carrying 
    }

    void EquipWeapon()
    {
        while (isWeaponChanging == true)
        {
            currentWEquipped = Instantiate(currentWEquipped, playerWSlot.transform.position, Quaternion.identity) as GameObject;
            currentWEquipped.transform.parent = GameObject.FindWithTag("PlayerCamera").transform;
            currentWEquipped.transform.rotation = playerWSlot.transform.rotation;
            isWeaponChanging = false;

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Object.Destroy(currentWEquipped);
            currentWEquipped = weaponController.weapons[0];
            isWeaponChanging = true;
            isWeaponEquipped[0] = true;

        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Object.Destroy(currentWEquipped);
            currentWEquipped = weaponController.weapons[1];
            isWeaponChanging = true;
            isWeaponEquipped[0] = true;

        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Object.Destroy(currentWEquipped);
            currentWEquipped = weaponController.weapons[2];
            isWeaponChanging = true;
            isWeaponEquipped[0] = true;
        }
    }

    public void Fire()
    {
        //doesn't work
        if (currentWEquipped == weaponController.weapons[0])
        {
           //currentAmmoAmounts[0] =- 1f;
            Debug.Log("Used Pistol ammo");

        } else if (currentWEquipped == weaponController.weapons[1])
        {
            //currentAmmoAmounts[1] -= 1f;
            Debug.Log("Used rifle ammo");

        } else if (currentWEquipped == weaponController.weapons[2])
        {
           //currentAmmoAmounts[2] -= 1f;
            Debug.Log("Used MG ammo");
        }
        
    }
    //currentAmmoAmouts shows ammo for all weapons in the game

}
