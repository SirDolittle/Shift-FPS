using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBlue : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject[] enemyTypes;
    public GameObject twoButtonDoor;
    public bool hasSpawned; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnEnemies(); 
    }

    void spawnEnemies()
    {
        if (twoButtonDoor.GetComponent<TwoButtonDoor>().doorOpen == true && hasSpawned == false)
        {
            Debug.Log("Enemies Spawned"); 
             Instantiate(enemyTypes[1], spawnLocations[0].transform.position, Quaternion.identity);
             Instantiate(enemyTypes[0], spawnLocations[1].transform.position, Quaternion.identity);
            hasSpawned = true; 
        }
    }

}
