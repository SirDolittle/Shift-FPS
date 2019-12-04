using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float moveSpeed = 10; // move speed
    private float turnSpeed = 90; // turning speed (degrees/second)
    private float lerpSpeed = 5; // smoothing speed
    private float gravity = 9.8f; // gravity acceleration
    private float deltaGround = 0.2f; // character is grounded up to this distance
    public float jumpHeight = 100; // vertical jump initial speed
    private float jumpRange = 10; // range to detect target wall
    private float distGround; // distance from character position to ground
    private float cameraYAxis;
    private float jumpRotationSpeed = 2;
    private float vertSpeed = 0; // vertical jump current speed

    private Vector3 surfaceNormal; // current surface normal
    public Vector3 myNormal; // character normal
    public Vector3 hitNormal;
    public Vector3 hitPosition;
    private Vector3 relataiveRotation;
    private Vector2 cameraYRotation;

    private GameObject playerCamera;
    public GameObject gameController;
    public GameObject gravityShiftUI;

    private bool shiftKeyHeld = false;
    private bool isGrounded;
    public bool jumpingToWall = false; // flag &quot;I'm jumping to wall&quot;
    public bool gravityShift = false;
    private bool isPlayingSound; 

    public Transform myTransform;
    private CameraController cameraController;
    public CapsuleCollider capsuleCollider; // drag BoxCollider ref in editor
    private WeaponController weaponController;
    private TriggerEndState endsState;
    private p_GravityShiftStart p_GravityShiftStart;
    private p_GravityShiftStop p_GravityShiftStop;
    private FootSteps footSteps;

    public Rigidbody mBody;



    private void Start()
    {
        playerCamera = GameObject.FindWithTag("PlayerCamera");
        cameraController = FindObjectOfType<CameraController>();
        weaponController = FindObjectOfType<WeaponController>();
        p_GravityShiftStart = FindObjectOfType<p_GravityShiftStart>();
        p_GravityShiftStop = FindObjectOfType<p_GravityShiftStop>();
        footSteps = FindObjectOfType<FootSteps>(); 
        endsState = FindObjectOfType<TriggerEndState>();
        myNormal = transform.up; // normal starts as character up direction
        myTransform = transform;
        GetComponent<Rigidbody>().freezeRotation = true; // disable physics rotation
        distGround = capsuleCollider.height - capsuleCollider.center.y; // distance from transform.position to ground.

    }

    private void FixedUpdate()
    {
        // apply constant weight force according to character normal:
        GetComponent<Rigidbody>().AddForce(-gravity * GetComponent<Rigidbody>().mass * myNormal);
        GroundDectection();

        if (endsState.levelComplete == false)
        {
            UpdatePlayerForward();
            PlayerShoot();
            GravityUIControll();
            PlayerMovement();

        }

    }

    private void Update()
    {
        AudioController(); 
    }

    private void PlayerShoot()
    {
        if(Input.GetButton("Fire1") && weaponController.weaponHasFired == false && shiftKeyHeld == false)
        {
            //Insert Damage function
            weaponController.Fire();
        }
    }

    private void UpdatePlayerForward()
    {
        Vector3 myForward = Vector3.Cross(myTransform.right, myNormal); // find forward direction with new myNormal
        Quaternion targetRot = Quaternion.LookRotation(myForward, myNormal); // align character to the new myNormal while keeping the forward direction
        myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetRot, lerpSpeed * Time.deltaTime);
    }

    private void PlayerMovement()
    {
        myTransform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);  // move the character forth/back with Vertical axis
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            { // no: if grounded, jump up
                Vector3 jumpforce = myNormal.normalized * jumpHeight; 
               GetComponent<Rigidbody>().AddForce(jumpforce);

            }
        }
    }

    private void GravityUIControll()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shiftKeyHeld = true;
            gravityShiftUI.SetActive(true);
            Time.timeScale = 0.5f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
        }
        else
        {
            shiftKeyHeld = false;
            gravityShiftUI.SetActive(false);
            Time.timeScale = 1.0f;
            myTransform.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0); // Rotates the player model and camera
            cameraController.CameraYRotation();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

       

        
    }

    public void GravityForwards()
    {
        Ray ray;
        RaycastHit hit;
        ray = new Ray(myTransform.position, myTransform.forward);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        { // wall ahead?
            hitNormal = hit.normal;
            hitPosition = hit.point;
            gravityShift = true;
            JumpToWall(); // yes: jump to the wall
            Physics.gravity = -hit.normal * gravity;

        }

    }

    public void GravityBackwards()
    {
        Ray ray;
        RaycastHit hit;
        ray = new Ray(myTransform.position, -myTransform.forward);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        { // wall ahead?
            hitNormal = hit.normal;
            gravityShift = true;
            hitPosition = hit.point;
            JumpToWall(); // yes: jump to the wall
            Physics.gravity = -hit.normal * gravity;

        }

    }

    public void GravityRight()
    {
        Ray ray;
        RaycastHit hit;
        ray = new Ray(myTransform.position, myTransform.right);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        { // wall ahead?
            hitNormal = hit.normal;
            gravityShift = true;
            hitPosition = hit.point;
            JumpToWall(); // yes: jump to the wall
            Physics.gravity = -hit.normal * gravity;
        }
    }

    public void GravityLeft()
    {
        Ray ray;
        RaycastHit hit;
        ray = new Ray(myTransform.position, -myTransform.right);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        { // wall ahead?
            hitNormal = hit.normal;
            gravityShift = true;
            hitPosition = hit.point;
            JumpToWall(); // yes: jump to the wall
            Physics.gravity = -hit.normal * gravity;
        }
    }

    public void GravityUp()
    {
        Ray ray;
        RaycastHit hit;
        ray = new Ray(myTransform.position, myTransform.up);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        { // wall ahead?
            hitNormal = hit.normal;
            gravityShift = true;
            hitPosition = hit.point;
            JumpToWall(); // yes: jump to the wall
            Physics.gravity = -hit.normal * gravity;
        }
    }

    private void GroundDectection()
    {
        // update surface normal and isGrounded:
        Ray ray;
        RaycastHit hit;
        ray = new Ray(myTransform.position, -myNormal); // cast ray downwards
        if (Physics.Raycast(ray, out hit))
        { // use it to update myNormal and isGrounded
            isGrounded = hit.distance <= distGround + deltaGround;
            surfaceNormal = hit.normal;

        }
        else
        {
            isGrounded = false;

            // assume usual ground normal to avoid "falling forever"
            surfaceNormal = Vector3.up;
        }
    }


    private void AudioController()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            p_GravityShiftStart.PlayShiftStartSound();
            Debug.Log("Start shift sound");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            p_GravityShiftStop.PlayShiftStopSound();
            Debug.Log("Stop shift sound");
        }

        if (Input.GetButton("Vertical") && isGrounded == true || Input.GetButton("Horizontal") && isGrounded == true)
        {
            footSteps.PlayFootStepsSound();
        }
        else
        {
            footSteps.StopFootStepSound(); 
        }

    }
    private void JumpToWall()
    {
        // jump to wall
        myNormal = Vector3.Lerp(myNormal, surfaceNormal, lerpSpeed * Time.deltaTime); // Update myNormal 
        jumpingToWall = true; // signal it's jumping to wall

        StartCoroutine(jumpTime());
        //jumptime
    }

    private IEnumerator jumpTime()
    {
        for (float t = 0.0f; t < 1.0f;)
        {
            Time.timeScale = 0.5f;
            t += jumpRotationSpeed * Time.deltaTime;
            yield return null; // return here next frame
        }
        myNormal = hitNormal; // update myNormal
        jumpingToWall = false; // jumping to wall finished
        gravityShift = false;
        Time.timeScale = 1.0f;
     

    }

}