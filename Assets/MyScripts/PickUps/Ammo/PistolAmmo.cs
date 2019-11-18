using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmo : MonoBehaviour
{
    WeaponController weaponController;
    public int AmmoIncreaseAmmount;

    // Start is called before the first frame update
    void Start()
    {
        weaponController = FindObjectOfType<WeaponController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            weaponController.currentAmmoAmounts[0] += AmmoIncreaseAmmount;
            Object.Destroy(this.gameObject);
        }
        
        
    }
}
