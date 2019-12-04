using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : MonoBehaviour
{
    PlayerStats playerStats;
    SkewardsController skewardsController;
    private GameObject DamageUI;
    // Start is called before the first frame update
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        skewardsController = FindObjectOfType<SkewardsController>();
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
        if(other.tag == ("Player"))
        {
            playerStats.currentHealth -= 5;
            DamageUI.GetComponent<DamageIndication>().ShowDamageIndicator();
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
