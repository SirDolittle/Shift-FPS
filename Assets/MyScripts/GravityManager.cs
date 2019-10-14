using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    Vector3 LeftVector;
    Vector3 rightVector;
    Vector3 forwardVector;
    Vector3 BackwardsVector; 
    float CurrentRotation;
    public GameObject player;

     void FixedUpdate()
    {
        CurrentRotation = player.transform.rotation.eulerAngles.y;
        SimpleGravityDirection();
        GraivtyControls();

    }

    void SimpleGravityDirection()
    {
        Vector3[] GravityVectors = new[] { new Vector3(0f, 0f, 9.8f), new Vector3(0f, 0f, -9.8f), new Vector3(9.8f, 0f, 0f), new Vector3(-9.8f, 0f, 0f)}; // Creates a array for the GravityVectors 
        
        if (CurrentRotation >= 315f || CurrentRotation <= 45f) //If the player is faceing global forward set the gravity direction veriables
        {
            forwardVector = GravityVectors[0];
            BackwardsVector = GravityVectors[1];
            rightVector = GravityVectors[2];
            LeftVector = GravityVectors[3];

        }
        else if (CurrentRotation <= 314f && CurrentRotation >= 225f) //If the player is faceing global Left set the gravity direction veriables
        {
            forwardVector = GravityVectors[3];
            BackwardsVector = GravityVectors[2];
            LeftVector = GravityVectors[1];
            rightVector = GravityVectors[0];
        }
        else if (CurrentRotation <= 224f && CurrentRotation >= 135f) //If the player is faceing global behind set the gravity direction veriables
        {
            forwardVector = GravityVectors[1];
            BackwardsVector = GravityVectors[0];
            LeftVector = GravityVectors[2];
            rightVector = GravityVectors[3];
        }
        else if (CurrentRotation <= 135f && CurrentRotation >= 45f) //If the player is faceing global right set the gravity direction veriables
        {
            forwardVector = GravityVectors[2];
            BackwardsVector = GravityVectors[3];
            LeftVector = GravityVectors[0];
            rightVector = GravityVectors[1];
        }


    }

    //Complex Gravity Directions function
    //if the DOWN Gravity Vector equals A +Z value  
        //Set UP Gravity Vector equals -Z 
        //Set CurrentRotation equals the players X rotation 
        //if the players rotation is in between 
    //if the DOWN Gravity Vector equals A -Z value 
    //if the DOWN Gravity Vector equals A +Y value 
    //if the DOWN Gravity Vector equals A -Y value 
    //if the DOWN Gravity Vector equals A +X value 
    //if the DOWN Gravity Vector equals A -X value 


    void GraivtyControls()
    {

        if (Input.GetKey("up"))
        {
            GravityForward();
        }
        if (Input.GetKey("down"))
        {
            GravityBackward();
        }
        if (Input.GetKey("left"))
        {
            GravityLeft();
        }
        if (Input.GetKey("right"))
        {
            GravityRight();
        }
        if (Input.GetKey(KeyCode.PageDown))
        {
            GravityDown();
        }
        if (Input.GetKey(KeyCode.PageUp))
        {
            GravityUP();
        }
    }

    bool GravityUP() //function to call to change the gravity to UP
    {
        Physics.gravity = new Vector3(0, 9f, 0);

        return true;
    }
    bool GravityDown() //function to call to change the gravity to Down
    {
        Physics.gravity = new Vector3(0, -9f, 0);

        return true;
    }

    bool GravityLeft() //function to call to change the gravity to left
    {

        Physics.gravity = LeftVector;

        return true;
    }
    bool GravityRight() //function to call to change the gravity to right
    {
        Physics.gravity = rightVector;

        return true;
    }
    bool GravityForward() //function to call to change the gravity to forward
    {
        
        Physics.gravity = forwardVector;

        return true;
    }
    bool GravityBackward() //function to call to change the gravity to backwards
    {
        Physics.gravity = BackwardsVector;

        return true;
    }



    // Start is called before the first frame update
    
    
    // Update is called once per frame
    
}

