using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePickup : MonoBehaviour
{
    WeaponController weaponController;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        transform.Rotate(0, 50f * Time.deltaTime, 0);
    }
    void Start()
    {
        weaponController = FindObjectOfType<WeaponController>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            weaponController.weaponInInventory[1] = true;
            Object.Destroy(this.gameObject);
        }
    }
}
