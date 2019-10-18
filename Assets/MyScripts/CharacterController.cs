﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    private float moveSpeed = 6; // move speed
    private float turnSpeed = 90; // turning speed (degrees/second)
    private float lerpSpeed = 5; // smoothing speed
    private float gravity = 9.8f; // gravity acceleration
    private bool isGrounded;
    private float deltaGround = 0.2f; // character is grounded up to this distance
    private float jumpSpeed = 10; // vertical jump initial speed
    private float jumpRange = 10; // range to detect target wall
    private Vector3 surfaceNormal; // current surface normal
    private Vector3 myNormal; // character normal
    private Vector3 relataiveRotation;
    private float distGround; // distance from character position to ground
    private bool jumping = false; // flag &quot;I'm jumping to wall&quot;
    private float vertSpeed = 0; // vertical jump current speed
    private GameObject playerCamera;
    public GameObject gameController;
    public GameObject gravityShiftUI;
    private Vector2 cameraYRotation;
    private float cameraYAxis;
    private float jumpRotationSpeed = 2;
    private bool shiftKeyHeld = false;
    private CameraController cameraController;

    private Transform myTransform;
    public CapsuleCollider capsuleCollider; // drag BoxCollider ref in editor

    private void Start()
    {
        playerCamera = GameObject.FindWithTag("PlayerCamera");
        cameraController = FindObjectOfType<CameraController>();
        myNormal = transform.up; // normal starts as character up direction
        myTransform = transform;
        GetComponent<Rigidbody>().freezeRotation = true; // disable physics rotation
        distGround = capsuleCollider.height - capsuleCollider.center.y; // distance from transform.position to ground

    }

    private void FixedUpdate()
    {
        // apply constant weight force according to character normal:
        GetComponent<Rigidbody>().AddForce(-gravity * GetComponent<Rigidbody>().mass * myNormal);

        GravityUIControll();
    }

    private void Update()
    {
       
        GroundDectection();
        PlayerMovement();
        UpdatePlayerForward();
       

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
    }

    private void GravityUIControll()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shiftKeyHeld = true;
        }
        else
        {
            shiftKeyHeld = false;
        }


        if (shiftKeyHeld == true)
        {
            gravityShiftUI.SetActive(true);
            Time.timeScale = 0.5f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //call GravityUIController script
        }
        else
        {
            gravityShiftUI.SetActive(false);
            Time.timeScale = 1.0f;
            myTransform.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0); // Rotates the player model and camera
            cameraController.CameraYRotation();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                { // no: if grounded, jump up
                    GetComponent<Rigidbody>().velocity += jumpSpeed * myNormal;
                }
           }
    }

    public void GravityForwards()
    {
        Ray ray;
        RaycastHit hit;
        ray = new Ray(myTransform.position, myTransform.forward);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        { // wall ahead?
            JumpToWall(hit.point, hit.normal); // yes: jump to the wall
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
            JumpToWall(hit.point, hit.normal); // yes: jump to the wall
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
            JumpToWall(hit.point, hit.normal); // yes: jump to the wall
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
            JumpToWall(hit.point, hit.normal); // yes: jump to the wall
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
            JumpToWall(hit.point, hit.normal); // yes: jump to the wall
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

    private void JumpToWall(Vector3 point, Vector3 normal)
    {
        // jump to wall
        myNormal = Vector3.Lerp(myNormal, surfaceNormal, lerpSpeed * Time.deltaTime); // Update myNormal 
        jumping = true; // signal it's jumping to wall
        Quaternion orgRot = myTransform.rotation;
        Vector3 dstPos = point + normal * (distGround + 0.5f); // will jump to 0.5 above wall
        Vector3 myForward = Vector3.Cross(myTransform.right, normal);
        Quaternion dstRot = Quaternion.LookRotation(myForward, normal);
        

        StartCoroutine(jumpTime( orgRot, dstPos, dstRot, normal));
        //jumptime
    }

    private IEnumerator jumpTime(Quaternion orgRot, Vector3 dstPos, Quaternion dstRot, Vector3 normal)
    {
        for (float t = 0.0f; t < 1.0f;)
        {
            Time.timeScale = 0.5f;
            t += jumpRotationSpeed * Time.deltaTime;
          //  myTransform.rotation = Quaternion.Slerp(orgRot, dstRot, t);
            yield return null; // return here next frame
        }
        myNormal = normal; // update myNormal
        //GetComponent<Rigidbody>().isKinematic = false; // enable physics
        jumping = false; // jumping to wall finished
        Time.timeScale = 1.0f;
     

    }

}