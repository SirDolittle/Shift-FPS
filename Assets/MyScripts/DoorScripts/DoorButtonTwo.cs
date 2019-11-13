using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorButtonTwo : MonoBehaviour
{
    public Text pressE;
    public Material sidePillar; 
    TwoButtonDoor buttonDoor;
    private bool doorOpen = false;
    public ButtonTracker buttonTracker;
    // Start is called before the first frame update

    void Awake()
    {
        buttonDoor = FindObjectOfType<TwoButtonDoor>();
        sidePillar.DisableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (doorOpen == false)
            {
                Debug.Log("Button pressed");
                sidePillar.EnableKeyword("_EMISSION");
                buttonTracker.buttonsPressed[1] = true;

                if (buttonTracker.buttonsPressed[0] == true && buttonTracker.buttonsPressed[1] == true)
                {
                    Debug.Log("Door Opened");
                    doorOpen = true;
                    StartCoroutine(buttonDoor.OpenDoor());
                }
            }
            else 
            {
                Debug.Log("Door Closed");
                StartCoroutine(buttonDoor.CloseDoor());
                sidePillar.DisableKeyword("_EMISSION");
                buttonTracker.buttonsPressed[1] = false;
                doorOpen = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pressE.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pressE.gameObject.SetActive(false);
        }
    }


}
