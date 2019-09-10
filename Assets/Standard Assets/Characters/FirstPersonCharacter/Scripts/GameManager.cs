using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        Physics.gravity = new Vector3(-9f, 0, 0);

        return true;
    }
    bool GravityRight() //function to call to change the gravity to right
    {
        Physics.gravity = new Vector3(9f, 0, 0);

        return true;
    }
    bool GravityForward() //function to call to change the gravity to forward
    {
        Physics.gravity = new Vector3(0, 0, 9f);

        return true;
    }
    bool GravityBackward() //function to call to change the gravity to backwards
    {
        Physics.gravity = new Vector3(0, 0, -9f);

        return true;
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
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
}
