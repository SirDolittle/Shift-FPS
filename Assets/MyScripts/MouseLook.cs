using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float CurrentUpRotation = 0.0f; // rotation around the up/y axis
    private float CurrentSideRotation = 0.0f; // rotation around the right/x axis

    void Start()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        CurrentUpRotation = rot.y;
        CurrentSideRotation = rot.x;
    }

    void Update()
    {
        //store an array for the different input angles
            //set mouseX and mouseY dependant on the players rotation

        //if players Z rotation = 90 
            //set CurrentSideRotation to the Y axis
            //Set CurrentUpRotation to the X axis 
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        CurrentUpRotation += mouseX * mouseSensitivity * Time.deltaTime;
        CurrentSideRotation += mouseY * mouseSensitivity * Time.deltaTime;

        CurrentSideRotation = Mathf.Clamp(CurrentSideRotation, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(CurrentSideRotation, CurrentUpRotation, 0.0f);
        transform.rotation = localRotation;
    }
}