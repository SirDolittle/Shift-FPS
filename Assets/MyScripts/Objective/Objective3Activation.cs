using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective3Activation : MonoBehaviour
{
    public ObjectiveBools objectiveBools;
    ObjectiveTracker objectiveTracker;
    // Start is called before the first frame update
    void Start()
    {
        objectiveTracker = FindObjectOfType<ObjectiveTracker>(); 
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            objectiveBools.ObjectivesCompleted[1] = true;
            objectiveTracker.ObjectiveCheck();
        }
    }
}
