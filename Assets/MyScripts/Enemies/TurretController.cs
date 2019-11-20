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
    public bool isShooting = false;

    CharacterController characterController;
    EnemyStats enemyStats;
    TurretTurning turretTurning;
    TurretFiringFX turretFiringFX; 
    // Start is called before the first frame update
    void Awake()
    {
        characterController = FindObjectOfType<CharacterController>();
        enemyStats = FindObjectOfType<EnemyStats>();
        turretTurning = FindObjectOfType<TurretTurning>();
        GetComponent<Collider>().attachedRigidbody.useGravity = false;
        GetComponent<Collider>().attachedRigidbody.isKinematic = true;
        player = GameObject.FindWithTag("Player");
        turretFiringFX = FindObjectOfType<TurretFiringFX>(); 
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


    void DeathCheck()
    {
        if (Turret.GetComponent<EnemyStats>().currentEnemyHealth <= 0)
        {
            GetComponent<Collider>().attachedRigidbody.isKinematic = false;
            GetComponent<Collider>().attachedRigidbody.useGravity = true;
            t_dead = true;
            turretTurning.StopTuringSound();
        }
    }

    void TrackPlayer()
    {

        Vector3 relativePos = player.transform.position - transform.position;
        Quaternion lookAtRotation = Quaternion.LookRotation(relativePos);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, relativePos , out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == ("Player"))
            {
                if (transform.rotation != lookAtRotation)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, speed * Time.deltaTime);
                    turretTurning.PlayturningSound();
                }
                else if (isShooting == false)
                {

                    turretFiringFX.PlayturFireSound();
                    isShooting = true;
                    FireAtPlayer();
                    StartCoroutine(FireRate());
                }
            }

        }

        if (isShooting == true)
        {
            turretTurning.StopTuringSound();
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
        plasmaBall.GetComponent<Rigidbody>().AddForce(transform.forward * 3000);
    }


}
