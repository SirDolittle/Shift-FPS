using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject player;
    public GameObject Turret;
    private GameObject plasmaBall;
    public GameObject turretEnd;
    public GameObject plasmaPrefab;

    public float fireRate;
    public float maxRange = 5f;
    public float speed;
    private bool t_dead = false;
    private bool isShooting = false; 

    CharacterController characterController;
    EnemyStats enemyStats;
    // Start is called before the first frame update
    void Awake()
    {
        characterController = FindObjectOfType<CharacterController>();
        enemyStats = FindObjectOfType<EnemyStats>();
        GetComponent<Collider>().attachedRigidbody.useGravity = false;
        GetComponent<Collider>().attachedRigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        DeathCheck();
        float p_distance = Vector3.Distance(player.transform.position, transform.position);
        if (p_distance <= maxRange && t_dead == false) 
        {
            TrackPlayer();  
        }
    }

    /*Turret to do list:
     * Fire projectile 
     * Range check 
     * line of sght check. 
     */

     void DeathCheck()
    {
        if (Turret.GetComponent<EnemyStats>().currentEnemyHealth <= 0)
        {
            GetComponent<Collider>().attachedRigidbody.isKinematic = false;
            GetComponent<Collider>().attachedRigidbody.useGravity = true;
            t_dead = true; 
        }
    }

    void TrackPlayer()
    { 

        Vector3 relativePos = player.transform.position - transform.position;
        Quaternion lookAtRotation = Quaternion.LookRotation(relativePos);

        if (transform.rotation != lookAtRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, speed * Time.deltaTime);
        }
        else if (isShooting == false)
        {
            isShooting = true; 
            FireAtPlayer();
            StartCoroutine(FireRate());
        }

        IEnumerator FireRate()
        {
            yield return new WaitForSeconds(fireRate);
            isShooting = false;
        }
    }

    void FireAtPlayer()
    {
        plasmaBall = Instantiate(plasmaPrefab, turretEnd.transform.position, transform.rotation);
        plasmaBall.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
    }

  

}
