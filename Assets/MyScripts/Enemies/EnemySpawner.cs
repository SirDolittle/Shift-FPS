using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject[] enemyTypes;
    public GameObject[] otherLoctations; 
    public bool hasSpawned;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

    private void OnTriggerEnter(Collider other)
    {
        if (hasSpawned == false && other.tag == "Player")
        {
            Instantiate(enemyTypes[0], spawnLocations[0].transform.position, Quaternion.identity);
            Instantiate(enemyTypes[0], spawnLocations[1].transform.position, Quaternion.identity);
            Instantiate(enemyTypes[1], spawnLocations[2].transform.position, Quaternion.identity);
            Instantiate(enemyTypes[0], spawnLocations[3].transform.position, Quaternion.identity);
            Instantiate(enemyTypes[0], spawnLocations[4].transform.position, Quaternion.identity);
            Instantiate(enemyTypes[0], spawnLocations[5].transform.position, Quaternion.identity);
            Instantiate(enemyTypes[1], spawnLocations[6].transform.position, Quaternion.identity);
            Instantiate(enemyTypes[1], spawnLocations[7].transform.position, Quaternion.identity);
            Instantiate(enemyTypes[0], spawnLocations[8].transform.position, Quaternion.identity);
            Instantiate(enemyTypes[0], spawnLocations[9].transform.position, Quaternion.identity);
            hasSpawned = true;
            Object.Destroy(otherLoctations[0]);
            Object.Destroy(otherLoctations[1]);
            Object.Destroy(otherLoctations[2]);
        }
    }

}
