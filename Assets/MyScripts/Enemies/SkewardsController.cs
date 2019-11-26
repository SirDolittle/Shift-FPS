using System.Collections;
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
        myNormal = transform.up;
        GetComponent<Rigidbody>().freezeRotation = true; // disable physics rotation
    }

    private void FixedUpdate()
    {
       GetComponent<Rigidbody>().AddForce(-gravity * GetComponent<Rigidbody>().mass * myNormal);
        if (isSkewardDead == false)
        {
            UpdateForward();
        }
        GravityChangeCheck();
        GroundDectection();
        DeathCheck();
        RangeCheck();
    }

    void Update()
    {
       
    }

    void GravityChangeCheck()
    {
        if (characterController.gravityShift == true)
        {
            skewardNav.enabled = false;
            myNormal = characterController.hitNormal;
            myNormal = Vector3.Lerp(myNormal, surfaceNormal, lerpSpeed * Time.deltaTime); // Update myNormal 
            
        }
        else if (isSkewardDead == false && playerInSight == true)
        {
           skewardNav.destination = player.transform.position;
        }
    }

    private void UpdateForward()
    {
        Vector3 myForward = Vector3.Cross(transform.right, myNormal); // find forward direction with new myNormal
        Quaternion targetRot = Quaternion.LookRotation(myForward, myNormal); // align character to the new myNormal while keeping the forward direction
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, lerpSpeed * Time.deltaTime);


    }

    private void GroundDectection()
    {
        // update surface normal and isGrounded:
        Ray ray;
        RaycastHit hit;
        if (skewardNav.enabled == false)
        {
            ray = new Ray(transform.position, -myNormal); // cast ray downwards
            if (Physics.Raycast(ray, out hit, 1f))
            { // use it to update myNormal and isGrounded
                surfaceNormal = hit.normal;
                skewardNav.enabled = true;
            }
            else
            {
                // assume usual ground normal to avoid "falling forever"
                surfaceNormal = Vector3.up;
            }
        }
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
