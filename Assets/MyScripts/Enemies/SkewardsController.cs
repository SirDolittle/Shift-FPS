﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkewardsController : MonoBehaviour
{ 
    public int meleeDamage = 15;
    public int thowingKnifeDamage = 5;
    public int throwingknifeAmmount;
    public float SkewardSightRange;
    public GameObject knifeThrowOrigin;
    public GameObject throwingKnifeOBJ;

    private float gravity = 9.8f;
    private float lerpSpeed = 5f;
    private float jumpRotationSpeed;
    private bool inThrowingRange = false;

    public bool isSkewardDead = false;
    public bool inMelee = false;
    private bool isThrowing = false;
    private bool playerInSight = false;
    private bool isOnGround = true;

    private Vector3 surfaceNormal;
    private Vector3 myNormal;
    private GameObject player;
    private CharacterController characterController;
    private PlayerStats playerStats;
    private DamageIndication damageIndication;
    private NavMeshAgent skewardNav;
    private GameObject prefabKnife;
    private EnemyStats enemyStats;

    void Awake()
    {
        skewardNav = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        characterController = FindObjectOfType<CharacterController>();
        playerStats = FindObjectOfType<PlayerStats>();
        damageIndication = FindObjectOfType<DamageIndication>();
        enemyStats = FindObjectOfType<EnemyStats>();
    }
    void Start()
    {
        skewardNav.enabled = false;
        myNormal = transform.up;
        StartCoroutine(startNavMeshAgent());
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(-gravity * GetComponent<Rigidbody>().mass * myNormal);

        GravityChangeCheck();
        DeathCheck();
        RangeCheck();
    }

    void Update()
    {

    }

    void GravityChangeCheck()
    {
        if (characterController.gravityShift == true )
        {
            skewardNav.enabled = false;
            myNormal = characterController.hitNormal;
            myNormal = Vector3.Lerp(myNormal, surfaceNormal, lerpSpeed * Time.deltaTime); // Update myNormal 
            if (isSkewardDead == false)
            {
                StartCoroutine(startNavMeshAgent());
            }
        }
        else if (isSkewardDead == false && playerInSight == true)
        {
            skewardNav.destination = player.transform.position;
        }
    }

    IEnumerator startNavMeshAgent()
    {
        yield return new WaitForSeconds(5f);
        skewardNav.enabled = true;
    }

    void DeathCheck()
    {
        
        if(gameObject.GetComponent<EnemyStats>().currentEnemyHealth <= 0)
        {
            //play death animation 
            isSkewardDead = true;
            GetComponent<Rigidbody>().freezeRotation = false;
            skewardNav.enabled = false;
        }
    }

   
    void RangeCheck()
    {
        Vector3 relativePos = player.transform.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, relativePos, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == ("Player"))
            {

                float playerDist = Vector3.Distance(player.transform.position, transform.position);
                if (playerDist <= SkewardSightRange)
                {
                    playerInSight = true;
                }
                if (playerDist >= 5 && playerDist <= 15 && isSkewardDead == false && isThrowing == false && throwingknifeAmmount >= 1)
                {

                    StopAndLookAtPlayer();
                    ThrowKnife();
                    StartCoroutine(ThrowRate());

                }
                else if (playerDist < 5 || playerDist > 15)
                {
                    gameObject.GetComponent<NavMeshAgent>().speed = 8;
                }

                IEnumerator ThrowRate()
                {
                    yield return new WaitForSeconds(2f);
                    isThrowing = false;
                }
            }
        }
    }

    void ThrowKnife()
    {
        Debug.Log("Throw Knife");
        isThrowing = true;
        throwingknifeAmmount -= 1;
        prefabKnife = Instantiate(throwingKnifeOBJ, knifeThrowOrigin.transform.position, transform.rotation);
        prefabKnife.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);

    }

    void StopAndLookAtPlayer()
    {
        gameObject.GetComponent<NavMeshAgent>().speed = 0;
        transform.LookAt(player.transform, myNormal);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && inMelee == false && isSkewardDead == false)
        {
            inMelee = true;
            playerStats.currentHealth -= 15;
            damageIndication.ShowDamageIndicator();
            StartCoroutine(MeleeRate());
        }

        IEnumerator MeleeRate()
        {
            yield return new WaitForSeconds(2f);
            inMelee = false;
        }
    }


}
