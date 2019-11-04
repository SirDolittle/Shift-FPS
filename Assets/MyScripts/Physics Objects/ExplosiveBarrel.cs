using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{

    public int barrelHP = 50;
    public float maxDamage = 200;
    public float minDamage = 10;
    public float maxDistance = 10;
    public float ExplosionForce;
    public float ExplosionsLift;

    PlayerStats playerStats;
    DamageIndication damageIndication;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        damageIndication = FindObjectOfType<DamageIndication>();
    }

    public void ExplodeCheck()
    {
        if(barrelHP <= 0)
        {
            StartCoroutine(ExplodeTimer());
        }


    }

    void ExplodeEffects()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject enemy = GameObject.FindWithTag("Enemy"); 
        float p_Distance = Vector3.Distance(player.transform.position, transform.position);
        float e_Distance = Vector3.Distance(enemy.transform.position, transform.position);

        float p_currentDistance = p_Distance / maxDistance;
        float e_currentDistance = e_Distance / maxDistance;

        float p_damage = Mathf.Lerp(maxDamage, minDamage, p_currentDistance);
        float e_damage = Mathf.Lerp(maxDamage, minDamage, e_currentDistance);


        if (p_currentDistance <= 1)
        {
            playerStats.currentHealth -= (int)p_damage;
            damageIndication.ShowDamageIndicator();
        }

        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, maxDistance);
        foreach (Collider col in enemiesInRange)
        {
            SkewardsController skewardsController = col.GetComponent<SkewardsController>(); 
            if (skewardsController != null)
            {
                skewardsController.currentHealth -= (int)e_damage;
            }
                
        }

        Collider[] colldiers = Physics.OverlapSphere(transform.position, maxDistance);
        foreach (Collider hit in colldiers)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(ExplosionForce, transform.position, maxDistance, ExplosionsLift);
            }
        }


        
    }

    IEnumerator ExplodeTimer()
    {

        yield return new WaitForSeconds(3f);
        ExplodeEffects(); 
        Destroy(gameObject);
    }


}
