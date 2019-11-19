using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPickup : MonoBehaviour
{
    public int HealthAmount;
    PlayerStats playerStats;
    GameObject player;
    public float h_speed;
    HealthInducation healthInducation;
    PlayHealthNoise playHealthNoise;    // Start is called before the first frame update

    private void FixedUpdate()
    {
        MoveTowardsPlayer(); 
    }

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        healthInducation = FindObjectOfType<HealthInducation>();
        playHealthNoise = FindObjectOfType<PlayHealthNoise>();
        player = GameObject.FindWithTag("Player"); 
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

    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, h_speed * Time.deltaTime);
    }

}
