using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int HealthAmount;
    PlayerStats playerStats;
    HealthInducation healthInducation;
    PlayHealthNoise playHealthNoise;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        healthInducation = FindObjectOfType<HealthInducation>();
        playHealthNoise = FindObjectOfType<PlayHealthNoise>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerStats.currentHealth += HealthAmount;
            Object.Destroy(this.gameObject);
            healthInducation.ShowHealthIndicator();
            playHealthNoise.PlayHealthSound(); 

        }
    }

}
