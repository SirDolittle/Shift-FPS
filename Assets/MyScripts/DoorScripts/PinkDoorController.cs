using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PinkDoorController : MonoBehaviour
{
    public Text pressE;
    public Text KeycardRequired;
    public bool doorOpen = false;
    private Vector3 currentPosition;
    private Vector3 openPosition;
    private Vector3 closedposition;
    private Vector3 openedDoor;
    public float openSpeed;
    PlayerStats playerStats;
    OpenDoorSound openDoorSound;
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Start()
    {
        currentPosition = transform.position;
        openPosition = new Vector3(0, 3, 0);
        openedDoor = currentPosition + openPosition;
        openSpeed = Vector3.Distance(currentPosition, openedDoor);
        openDoorSound = FindObjectOfType<OpenDoorSound>(); 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           
            if(playerStats.KeysEquipped[0] == false)
            {
              KeycardRequired.gameObject.SetActive(true);
            } else
            {
                pressE.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
           
            if (playerStats.KeysEquipped[0] == false)
            {
                KeycardRequired.gameObject.SetActive(false);
            } else
            {
                pressE.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && doorOpen == false && playerStats.KeysEquipped[0] == true)
        {
            Debug.Log("Door Opened");
            doorOpen = true;
            openDoorSound.PlayOpenDoorSound();
            StartCoroutine(OpenDoor());
           
        }
    }

    IEnumerator OpenTimer()
    {
        yield return new WaitForSeconds(2f);
        doorOpen = false;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / 2;
            transform.position = Vector3.Lerp(openedDoor, currentPosition, t);


            yield return null;
        }
    }


    IEnumerator OpenDoor()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 2;
            transform.position = Vector3.Lerp(currentPosition, openedDoor, t);


            yield return null;
        }
        StartCoroutine(OpenTimer());
        yield return null;
    }

   



}
