using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHealth = 100;
    public int currentEnemyHealth;
    public int HealthSpawned; 
    public GameObject E_healthPrefab;
    public bool spawnhealth;
    WeaponController weaponController;

    // Start is called before the first frame update
    void Start()
    {
        currentEnemyHealth = enemyHealth;
        spawnhealth = true;
        weaponController = FindObjectOfType<WeaponController>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (currentEnemyHealth <= 0)
        {
            currentEnemyHealth = 0;
           if(spawnhealth == true && weaponController.isWeaponEquipped[0])
            {
                for (int i = 0; i < HealthSpawned; i++)
                {
                    E_healthPrefab = GameObject.Instantiate(E_healthPrefab, transform.position, Quaternion.identity);
                    E_healthPrefab.GetComponent<Rigidbody>().AddForce(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
                }
                    spawnhealth = false;
            } else
            {
                spawnhealth = false;
            }
        } 
 
    }

}
