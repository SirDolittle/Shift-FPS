using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorButton : MonoBehaviour
{
    public Text pressE;
    public Material sidePillar; 
    ButtonDoor buttonDoor;
    private bool doorOpen = false;
    bool eIsPressed; 
    // Start is called before the first frame update

    void Awake()
    {
        buttonDoor = FindObjectOfType<ButtonDoor>();
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
                Debug.Log("Door Opened");
                sidePillar.EnableKeyword("_EMISSION");
                StartCoroutine(buttonDoor.OpenDoor());
                doorOpen = true;
            }
            else if (doorOpen == true)
            {
                Debug.Log("Door Closed");
                StartCoroutine(buttonDoor.CloseDoor());
                sidePillar.DisableKeyword("_EMISSION");
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
