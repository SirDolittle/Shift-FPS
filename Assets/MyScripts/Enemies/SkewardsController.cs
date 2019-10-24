using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkewardsController : MonoBehaviour
{ 
    public int meleeDamage = 15;
    public int thowingKnifeDamage = 5;
    public float movementSpeed = 10;
    public int maxHealth = 50;
    public int currentHealth; 


    private float gravity = 9.8f;
    private float lerpSpeed = 5f;
    private float jumpRotationSpeed;

    public bool isSkewardDead = false;
    public bool inMelee = false;

    private Vector3 surfaceNormal;
    private Vector3 myNormal;
    private GameObject player;
    private CharacterController characterController;
    private PlayerStats playerStats;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        characterController = FindObjectOfType<CharacterController>();
        playerStats = FindObjectOfType<PlayerStats>();
    }
    void Start()
    {

        currentHealth = maxHealth;
        myNormal = transform.up;
        GetComponent<Rigidbody>().freezeRotation = true; // disable physics rotation
    }

    private void FixedUpdate()
    {
       GetComponent<Rigidbody>().AddForce(-gravity * GetComponent<Rigidbody>().mass * myNormal);
    }

    void Update()
    {
        if(isSkewardDead == false)
        {
            UpdateForward();
        }
        GroundDectection();
        GravityChangeCheck();
        DeathCheck();
    }

    void GravityChangeCheck()
    {
        if (characterController.gravityShift == true)
        {
            myNormal = characterController.hitNormal;
            myNormal = Vector3.Lerp(myNormal, surfaceNormal, lerpSpeed * Time.deltaTime); // Update myNormal 
        } else if (isSkewardDead == false)
        {
            transform.LookAt(player.transform.position, myNormal);
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
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
        ray = new Ray(transform.position, -myNormal); // cast ray downwards
        if (Physics.Raycast(ray, out hit))
        { // use it to update myNormal and isGrounded
            surfaceNormal = hit.normal;

        }
        else
        {
            // assume usual ground normal to avoid "falling forever"
            surfaceNormal = Vector3.up;
        }
    }

    void DeathCheck()
    {
        if(currentHealth <= 0)
        {
            //play death animation 
            isSkewardDead = true;
            GetComponent<Rigidbody>().freezeRotation = false;
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && inMelee == false && isSkewardDead == false)
        {
            inMelee = true;
            playerStats.currentHealth -= 15;
            StartCoroutine(MeleeRate());
        }

        IEnumerator MeleeRate()
        {
            yield return new WaitForSeconds(2f);
            inMelee = false;
        }
    }

    /*Move toward the player function
     *  When the player is within sight line 
     *      move the enemy towards the player at set speed 
     *  Once in sight line once the enemy constantly moves towards the player. 
     */

    /*Damage the player function 
     *  When the player is in line of sight 
     *      When within knife throwing range 
     *          stop moving
     *          Throw knife at player
     *      if the throwing knifes are out of ammo 
     *          move towards player 
     *          once in melee range stop moving
     *          melee player 
     *      if the player moves into melee range 
     *          melee player 
     * 
     */

    /*Throw Knife function 
     *  Play throw animation 
     *  play throw sound 
     *  spawn throwing knife prefab at the Skewards position 
     *  add force to the knife towards the player at thorwing knife speed
     */

}
