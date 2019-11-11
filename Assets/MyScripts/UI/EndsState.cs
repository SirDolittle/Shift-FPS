using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndsState : MonoBehaviour
{
    public bool levelComplete = false;
    public Canvas endCanvas;
    public Text pressE;

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                endCanvas.gameObject.SetActive(true);
                endCanvas.gameObject.GetComponent<ScreenFader>().fade();
                levelComplete = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
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
