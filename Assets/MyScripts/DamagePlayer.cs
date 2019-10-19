using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageAmount;
    private PlayerStats playerStats;
    // Start is called before the first frame update

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void Damage()
    {

    }
}
