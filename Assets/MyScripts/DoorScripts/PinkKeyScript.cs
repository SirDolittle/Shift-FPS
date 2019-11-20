using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkKeyScript : MonoBehaviour
{
    PlayerStats playerStats; 
    // Start is called before the first frame update
    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerStats.KeysEquipped[0] = true;
            Object.Destroy(gameObject);
        }
    }


}
