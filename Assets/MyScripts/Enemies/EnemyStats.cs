using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHealth = 100;
    public int currentEnemyHealth; 
    // Start is called before the first frame update
    void Start()
    {
        currentEnemyHealth = enemyHealth; 
    }

    // Update is called once per frame
    void Update()
    {
    
        if (currentEnemyHealth <= 0)
        {
            currentEnemyHealth = 0;
        }
    }


   

}
