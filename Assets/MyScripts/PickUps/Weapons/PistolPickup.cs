using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolPickup : MonoBehaviour
{
    WeaponController weaponController;
    // Start is called before the first frame update
    void Start()
    {
        weaponController = FindObjectOfType<WeaponController>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            weaponController.weaponInInventory[0] = true;
            Object.Destroy(this.gameObject);
        }
    }
}
