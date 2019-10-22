using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject currentWEquipped;
    public GameObject[] weapons;
    public float[] weaponAmmoAmounts;
    public bool[] isWeaponEquipped;
    public float[] currentAmmoAmounts;

    public bool isOutOfAmmo = false;
    private float fireRate;
    private int damage;

    private GameObject levelStartWeapon;
    public GameObject playerWSlot;

    private PlayerStats playerStats;

    private bool isWeaponChanging = false;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();


        isWeaponEquipped = new bool[3];
    
        levelStartWeapon = weapons[0];
        currentAmmoAmounts[0] = weaponAmmoAmounts[0];
        currentAmmoAmounts[1] = weaponAmmoAmounts[1];
        currentAmmoAmounts[2] = weaponAmmoAmounts[2];
        StartingWeapon();

    }

    // Update is called once per frame
    void Update()
    {
        EquipWeapon();
    }

    void playerWeaponPickUp()
    {
        //when the player walks over a dropped weapon
        //either 
        //adds the weapon into a new weapon slot
        //adds ammo to the ammo count
    }

    public void Fire()
    {
        //doesn't work
        if (isWeaponEquipped[0] == true && isOutOfAmmo == false)
        {
            Debug.Log("Used Pistol ammo");
            PistolStats();

        }
        else if (isWeaponEquipped[1] == true && isOutOfAmmo == false)
        {
            Debug.Log("Used rifle ammo");

        }
        else if (isWeaponEquipped[2] == true && isOutOfAmmo == false)
        {

            Debug.Log("Used MG ammo");
        }
    }

    void StartingWeapon()
    {

        currentWEquipped = levelStartWeapon;
        currentWEquipped = Instantiate(currentWEquipped, playerWSlot.transform.position, Quaternion.identity) as GameObject;
        currentWEquipped.transform.parent = GameObject.FindWithTag("PlayerCamera").transform;
        isWeaponEquipped[0] = true;
        isWeaponEquipped[1] = false;
        isWeaponEquipped[2] = false;

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
            currentWEquipped = weapons[0];
            isWeaponChanging = true;
            isWeaponEquipped[0] = true;
            isWeaponEquipped[1] = false;
            isWeaponEquipped[2] = false;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Object.Destroy(currentWEquipped);
            currentWEquipped = weapons[1];
            isWeaponChanging = true;
            isWeaponEquipped[0] = false;
            isWeaponEquipped[1] = true;
            isWeaponEquipped[2] = false;


        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Object.Destroy(currentWEquipped);
            currentWEquipped = weapons[2];
            isWeaponChanging = true;
            isWeaponEquipped[0] = false;
            isWeaponEquipped[1] = false;
            isWeaponEquipped[2] = true;

        }


        //things we want weapons to do:
        //Pick up 
        //shoot

    }

    void PistolStats()
    {
        currentAmmoAmounts[0] -= 1;

        if (currentAmmoAmounts[0] >= weaponAmmoAmounts[0]) //Check to see if the 
        {
          currentAmmoAmounts[0] = weaponAmmoAmounts[0];
        } else 
        if (currentAmmoAmounts[0] < 0)
        {
            currentAmmoAmounts[0] = 0;
            isOutOfAmmo = true;
        }


        //Fire Rate
            //
        //Damage
    }

    void RifleStats()
    {

    }

    void MGStats()
    {

    }
}
