using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TwoButtonDoor : MonoBehaviour
{
 
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



    public IEnumerator OpenDoor()
    {

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / 2;
            transform.position = Vector3.Lerp(currentPosition, openedDoor, t);
            yield return null;
        }

        yield return null;
    }

    public IEnumerator CloseDoor()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / 2;
            transform.position = Vector3.Lerp(openedDoor, currentPosition, t);


            yield return null;
        }
        yield return null;
    }




}
