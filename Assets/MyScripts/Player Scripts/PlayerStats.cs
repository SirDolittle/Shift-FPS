using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int startingPlayerHealth = 100;
    public int currentHealth;
    public Canvas deathCanvas;
    public bool[] KeysEquipped; 

    private bool isPlayerDead;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingPlayerHealth; //sets starting health to full
    }

    // Update is called once per frame
    void Update()
    {

        PlayerDeath();

    }

    void PlayerDeath()
    {
        if (currentHealth <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            deathCanvas.gameObject.SetActive(true);
            deathCanvas.gameObject.GetComponent<ScreenFader>().fade(); 
            Object.Destroy(GameObject.FindWithTag("Player").GetComponent<CharacterController>());
            Object.Destroy(GameObject.FindWithTag("Player").GetComponent<CapsuleCollider>());
            currentHealth = 0;
        }
    }
        
    }
