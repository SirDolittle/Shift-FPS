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

    private Color startingColor;
    PlayerStats playerStats;
    DamageIndication damageIndication;
    BarrelExplosionSound barrelExplosionSound;
    public GameObject soundEmitter; 

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        damageIndication = FindObjectOfType<DamageIndication>();
        startingColor = gameObject.GetComponent<Renderer>().material.color;
       

    }

    public void ExplodeCheck()
    {
        if (barrelHP <= 0)
        {
            StartCoroutine(ExplodeTimer());
            StartCoroutine(FadeColourIn());
           
        }
    }

    void ExplodeEffects()
    {
        print("Started effects"); 
        GameObject player = GameObject.FindWithTag("Player");
        GameObject enemy = GameObject.FindWithTag("Enemy");
        GameObject Explosive = GameObject.FindWithTag("Explosive");
        float p_Distance = Vector3.Distance(player.transform.position, transform.position);
       
        float p_currentDistance = p_Distance / maxDistance;
        Vector3 relativePos = player.transform.position - transform.position;

        float p_damage = Mathf.Lerp(maxDamage, minDamage, p_currentDistance);

        soundEmitter.GetComponent<BarrelExplosionSound>().PlayBExplosionSound(); 
        RaycastHit rayHit;
        if (Physics.Raycast(transform.position, relativePos, out rayHit, Mathf.Infinity))
        {
            if (rayHit.collider.tag == "Player")
            {
                if (p_currentDistance <= 1)
                {
                    playerStats.currentHealth -= (int)p_damage;
                    damageIndication.ShowDamageIndicator();
                }
            }
        }
            Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, maxDistance);
            foreach (Collider col in enemiesInRange)
            {
                EnemyStats enemyStats = col.GetComponent<EnemyStats>();
                ExplosiveBarrel explosiveBarrel = col.GetComponent<ExplosiveBarrel>();
                if (enemyStats != null)
                {
                    float e_Distance = Vector3.Distance(col.transform.position, transform.position);
                    float e_currentDistance = e_Distance / maxDistance;
                    float e_damage = Mathf.Lerp(maxDamage, minDamage, e_currentDistance);
                    enemyStats.currentEnemyHealth -= (int)e_damage;

                }


                
            }

            Collider[] barrelInRange = Physics.OverlapSphere(transform.position, maxDistance);
            foreach (Collider col in barrelInRange)
            {
                ExplosiveBarrel explosiveBarrel = col.GetComponent<ExplosiveBarrel>();
                if (explosiveBarrel != null)
                {
                    float e_Distance = Vector3.Distance(col.transform.position, transform.position);
                    float e_currentDistance = e_Distance / maxDistance;
                    float e_damage = Mathf.Lerp(maxDamage, minDamage, e_currentDistance);
                    explosiveBarrel.barrelHP -= (int)e_damage;
                    explosiveBarrel.ExplodeCheck();
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

    public IEnumerator FadeColourIn()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / 2;
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(startingColor, Color.red, t);

            yield return null;
        }
        yield return null;
    }

}
