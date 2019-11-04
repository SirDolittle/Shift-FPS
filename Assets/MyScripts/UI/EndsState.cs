using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndsState : MonoBehaviour
{
    public bool levelComplete = false;
    ScreenFader screenFader;
    public Text pressE;

    private void Awake()
    {
        screenFader = FindObjectOfType<ScreenFader>();
    }

    //if the player enters the trigger 
    //show end state UI 
    //Freeze time 

    private void OnTriggerStay(Collider other)
    {
      

        if (Input.GetKeyDown(KeyCode.E))
        {
            screenFader.fade();
            levelComplete = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        pressE.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        pressE.gameObject.SetActive(false);
    }

}
