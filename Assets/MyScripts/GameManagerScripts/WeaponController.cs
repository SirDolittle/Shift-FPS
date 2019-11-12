using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject currentWEquipped;
    public GameObject PlayerCamera;
    public GameObject[] weapons;
    public Sprite[] WeaponDisplayImage;
    public float[] weaponAmmoAmounts;
    public bool[] isWeaponEquipped;
    public float[] currentAmmoAmounts;
    public float[] weaponFireRate;
    public int[] weaponDamageStats;
    public int[] impactForce;
    

    public bool isOutOfAmmo = false;
    public bool weaponHasFired = false;
    private float fireRate;
    private int damage;

    private GameObject levelStartWeapon;
    public GameObject playerWSlot;
    public GameObject enemyHitName;

    private PlayerStats playerStats;
    private ExplosiveBarrel explosiveBarrel;


    private bool isWeaponChanging = false;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        explosiveBarrel = FindObjectOfType<ExplosiveBarrel>();

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
            PistolStats();
        }
        else if (isWeaponEquipped[1] == true && isOutOfAmmo == false)
        {

            RifleStats();
 
        }
        else if (isWeaponEquipped[2] == true && isOutOfAmmo == false)
        {
            MGStats();
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
            if (currentAmmoAmounts[0] <= weaponAmmoAmounts[0])
            {
                isOutOfAmmo = false;
            }
            if (currentAmmoAmounts[0] <= 0)
            {
                isOutOfAmmo = true;
            }

            Object.Destroy(currentWEquipped);
            currentWEquipped = weapons[0];
            isWeaponChanging = true;
            isWeaponEquipped[0] = true;
            isWeaponEquipped[1] = false;
            isWeaponEquipped[2] = false;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentAmmoAmounts[1] <= weaponAmmoAmounts[1])
            {
                isOutOfAmmo = false;
            }
            if (currentAmmoAmounts[1] <= 0)
            {
                isOutOfAmmo = true;
            }

            Object.Destroy(currentWEquipped);
            currentWEquipped = weapons[1];
            isWeaponChanging = true;
            isWeaponEquipped[0] = false;
            isWeaponEquipped[1] = true;
            isWeaponEquipped[2] = false;


        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentAmmoAmounts[2] <= weaponAmmoAmounts[2])
            {
                isOutOfAmmo = false;
            }
            if (currentAmmoAmounts[2] <= 0)
            {
                isOutOfAmmo = true;
            }
            Object.Destroy(currentWEquipped);
            currentWEquipped = weapons[2];
            isWeaponChanging = true;
            isWeaponEquipped[0] = false;
            isWeaponEquipped[1] = false;
            isWeaponEquipped[2] = true;

        }


        //things we want weapons to do:
        //Pick up 

    }

    void PistolStats()
    {

        if (currentAmmoAmounts[0] > weaponAmmoAmounts[0]) //Check to see if the weapon has reached max ammo
        {
          currentAmmoAmounts[0] = weaponAmmoAmounts[0]; // if so set the current ammo to equal the max ammo
        }
        if (currentAmmoAmounts[0] <= 0) //Check to see if the weapon is out of ammo 
        {
            currentAmmoAmounts[0] = 0; //Stops ammo from going into minus numbers
            isOutOfAmmo = true; //Stops the ability to fire the weapon
            Debug.Log("Out OF AMMO");
        }
        else
        {
            StartCoroutine(PistolFireRate());

            IEnumerator PistolFireRate()
            {
                Debug.Log("PISTOL FIRED");
                currentAmmoAmounts[0] -= 1f;
                weaponHasFired = true;
               
                RaycastHit hit;
                Ray ray = new Ray (PlayerCamera.transform.position, PlayerCamera.transform.forward);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity));
                {
                    
                    Debug.Log("Ray tag =" + hit.collider.tag);
                    if (hit.collider.tag == "Enemy")
                    {
                        Debug.Log("Enemy Hit!");
                        hit.collider.gameObject.GetComponent<EnemyStats>().currentEnemyHealth -= weaponDamageStats[0];
                        hit.collider.GetComponentInParent<EnemyStats>().currentEnemyHealth -= weaponDamageStats[0];

                    }
                    else if (hit.collider.tag == "Explosive")
                    {
                        explosiveBarrel.barrelHP -= weaponDamageStats[0];
                        explosiveBarrel.ExplodeCheck();
                    } 
                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(ray.direction * impactForce[0]);
                    }

                } 
                yield return new WaitForSeconds(weaponFireRate[0]);
                weaponHasFired = false;
            }

        }
        //Damage
    }

    void RifleStats()
    {
        if (currentAmmoAmounts[1] > weaponAmmoAmounts[1]) //Check to see if the weapon has reached max ammo
        {
            currentAmmoAmounts[1] = weaponAmmoAmounts[1]; // if so set the current ammo to equal the max ammo
        }
        else
        if (currentAmmoAmounts[1] <= 1) //Check to see if the weapon is out of ammo 
        {
            currentAmmoAmounts[1] = 0; //Stops ammo from going into minus numbers
            isOutOfAmmo = true; //Stops the ability to fire the weapon
            Debug.Log("Out OF AMMO");
        }
        else
        {
            StartCoroutine(RifleFireRate());

            IEnumerator RifleFireRate()
            {
                Debug.Log("Rifle FIRED");
                currentAmmoAmounts[1] -= 1f;
                weaponHasFired = true;
                RaycastHit hit;
                Ray ray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Debug.Log("Ray tag =" + hit.collider.tag);
                    if (hit.collider.tag == "Enemy")
                    {
                        Debug.Log("Enemy Hit!");
                        hit.collider.gameObject.GetComponent<EnemyStats>().currentEnemyHealth -= weaponDamageStats[1];
                        hit.collider.GetComponentInParent<EnemyStats>().currentEnemyHealth -= weaponDamageStats[1];
                    }
                    else if (hit.collider.tag == "Explosive")
                    {
                        explosiveBarrel.barrelHP -= weaponDamageStats[1];
                        explosiveBarrel.ExplodeCheck();
                    }
                    if (hit.rigidbody != null) 
                    {
                        hit.rigidbody.AddForce(ray.direction * impactForce[1]);
                    }

                }
                yield return new WaitForSeconds(weaponFireRate[1]);
                weaponHasFired = false;

            }
        }
        
    }

    void MGStats()
    {
        if (currentAmmoAmounts[2] > weaponAmmoAmounts[2]) //Check to see if the weapon has reached max ammo
        {
            currentAmmoAmounts[2] = weaponAmmoAmounts[2]; // if so set the current ammo to equal the max ammo
        }
        else
        if (currentAmmoAmounts[2] <= 1) //Check to see if the weapon is out of ammo 
        {
            currentAmmoAmounts[2] = 0; //Stops ammo from going into minus numbers
            isOutOfAmmo = true; //Stops the ability to fire the weapon
            Debug.Log("Out OF AMMO");
        }
        else
        {
            StartCoroutine(MGFireRate());

            IEnumerator MGFireRate()
            {
                Debug.Log("MG FIRED");
                currentAmmoAmounts[2] -= 1f;
                weaponHasFired = true;
                RaycastHit hit;
                Ray ray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Debug.Log("Ray tag =" + hit.collider.tag);
                    if (hit.collider.tag == "Enemy")
                    {
                        Debug.Log("Enemy Hit!");
                        hit.collider.gameObject.GetComponent<EnemyStats>().currentEnemyHealth -= weaponDamageStats[2];
                         hit.collider.GetComponentInParent<EnemyStats>().currentEnemyHealth -= weaponDamageStats[2];

                    }
                    else if (hit.collider.tag == "Explosive")
                    {
                        explosiveBarrel.barrelHP -= weaponDamageStats[2];
                        explosiveBarrel.ExplodeCheck();
                    }
                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(ray.direction * impactForce[2]);
                    }

                }
                yield return new WaitForSeconds(weaponFireRate[2]);
                weaponHasFired = false;

            }
        }
       
    }

}
