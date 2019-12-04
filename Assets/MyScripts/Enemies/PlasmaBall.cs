using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBall : MonoBehaviour
{
    PlayerStats playerStats;
    public int plasmaBall_D;
    private GameObject DamageUI; 
    // Start is called before the first frame update
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        DamageUI = GameObject.Find("DamageIndicator"); 
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            playerStats.currentHealth -= plasmaBall_D;
            DamageUI.GetComponent<DamageIndication>().ShowDamageIndicator(); 
            Destroy(gameObject);
        }
        else if (other.tag == "PickUp" || other.tag == "Enemy")
        {
            
        } else
        {
            Destroy(gameObject);
        }

    }
}

