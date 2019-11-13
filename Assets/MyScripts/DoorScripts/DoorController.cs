using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DoorController : MonoBehaviour
{
    public Text pressE;
    public bool doorOpen = false;
    private Vector3 currentPosition;
    private Vector3 openPosition;
    private Vector3 closedposition;
    private Vector3 openedDoor;
    public float openSpeed;
  




    private void Start()
    {
        currentPosition = transform.position;
        openPosition = new Vector3(0, 3, 0);
        openedDoor = currentPosition + openPosition;
        openSpeed = Vector3.Distance(currentPosition, openedDoor);
  
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

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && doorOpen == false )
        {
            Debug.Log("Door Opened");
            doorOpen = true;
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
            t += Time.deltaTime / 2;
            transform.position = Vector3.Lerp(currentPosition, openedDoor, t);


            yield return null;
        }
        StartCoroutine(OpenTimer());
        yield return null;
    }

   



}
