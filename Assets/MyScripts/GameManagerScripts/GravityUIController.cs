using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.


public class GravityUIController : MonoBehaviour
{

    public Button B_Forward, B_Right, B_Left, B_Backwards, B_UP;
    public bool[] buttonUsed;
    private GameObject player;
    private void Start()
    {
      player = GameObject.FindWithTag("Player");

        B_Forward.onClick.AddListener(player.GetComponent<CharacterController>().GravityForwards);
        B_Right.onClick.AddListener(player.GetComponent<CharacterController>().GravityRight);
        B_Left.onClick.AddListener(player.GetComponent<CharacterController>().GravityLeft);
        B_Backwards.onClick.AddListener(player.GetComponent<CharacterController>().GravityBackwards);
        B_UP.onClick.AddListener(player.GetComponent<CharacterController>().GravityUp);
        buttonUsed = new bool[5];
    }

    [ContextMenu("Check Gravity")]
    void GravityDirectionCheck()
    {
        print(Physics.gravity);
    }

}