using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : MonoBehaviour
{
    PlayerStats playerStats;
    SkewardsController skewardsController;
    private DamageIndication damageIndication;
    // Start is called before the first frame update
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        skewardsController = FindObjectOfType<SkewardsController>();
        damageIndication = FindObjectOfType<DamageIndication>();
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
        if(other.tag == ("Player"))
        {
            playerStats.currentHealth -= 5;
            damageIndication.ShowDamageIndicator(); 
            Destroy(gameObject);
        } 
        else
        {
            StartCoroutine(ThrowRate());

           
        }

    }
    IEnumerator ThrowRate()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }


}
