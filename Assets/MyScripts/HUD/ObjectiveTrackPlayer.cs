using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrackPlayer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        transform.LookAt(player.transform.position, Vector3.forward);
        float size = (player.transform.position - transform.position).magnitude;
        size = size / 100f; 
        transform.localScale = new Vector3(size, size, size); 
    }
}
