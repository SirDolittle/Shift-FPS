using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TriggerEndState : MonoBehaviour
{
    public bool levelComplete = false;
    public Canvas endCanvas;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            endCanvas.gameObject.SetActive(true);
            endCanvas.gameObject.GetComponent<ScreenFader>().fade();
            levelComplete = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }



}
