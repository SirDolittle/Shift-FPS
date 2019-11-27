using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGPickup : MonoBehaviour
{
    WeaponController weaponController;
    WeaponPickupSound weaponPickupSound;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        transform.Rotate(0, 50f * Time.deltaTime, 0);
    }

    void Start()
    {
        weaponController = FindObjectOfType<WeaponController>();
        weaponPickupSound = FindObjectOfType<WeaponPickupSound>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            weaponController.weaponInInventory[2] = true;
            Object.Destroy(this.gameObject);
            weaponPickupSound.PlayWPickSound();
        }
    }
}
