using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDamage : MonoBehaviour
{
    public int maxDamage;
    public int minDamage;
    Vector3 v_damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }




    private void OnCollisionEnter(Collision collision)
    {
        v_damage = gameObject.GetComponent<Rigidbody>().velocity;
        Debug.Log(v_damage);
    }

    /*Do damage to an entity with either player stats/ enemy stats
     * 
     * Ways to do the system: 
     * 1. 
     * Velocity x mass = damage 
     * 2. 
     * 
     */



}
