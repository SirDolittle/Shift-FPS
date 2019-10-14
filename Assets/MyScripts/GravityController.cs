using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    
    bool GravityUP() //function to call to change the gravity to UP
    {
        Physics.gravity = new Vector3(0, 9f, 0);

        return false;
    }

    bool GravityDown() //function to call to change the gravity to Down
    {
        Physics.gravity = new Vector3(0, -9f, 0);

        return false;
    }

    bool GravityLeft() //function to call to change the gravity to left
    {
        Physics.gravity = new Vector3(-9f, 0, 0);

        return false;
    }

    bool GravityRight() //function to call to change the gravity to right
    {
        Physics.gravity = new Vector3(9f, 0, 0);

        return false;
    }
    
    
    bool GravityForward() //function to call to change the gravity to forward
    {
        Physics.gravity = new Vector3(0, 0, 9f);

        return false;
    }


    
    bool GravityBackward() //function to call to change the gravity to backwards
    {
        Physics.gravity = new Vector3(0, 0, -9f);

        return false;
    }


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, 0, 9f);
    }



    // Update is called once per frame
    void Update()
    {


    }
}