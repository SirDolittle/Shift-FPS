using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretPowerLines : MonoBehaviour
{
    public GameObject[] attatchedTurrets;
    public GameObject[] attatchedTurretGlow;
    public Material disactive;
    public Text pressE; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            

            foreach (GameObject enemy in attatchedTurrets)
            {
                enemy.GetComponent<TurretController>().enabled = false;
            }

            foreach (GameObject enemy in attatchedTurretGlow)
            {
                enemy.GetComponent<Renderer>().material = disactive;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pressE.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pressE.gameObject.SetActive(false);
        }
    }

}
