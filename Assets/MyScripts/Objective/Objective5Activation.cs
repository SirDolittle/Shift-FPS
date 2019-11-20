using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective5Activation : MonoBehaviour
{
    public ObjectiveBools objectiveBools;
    ObjectiveTracker objectiveTracker;
    // Start is called before the first frame update
    void Start()
    {
        objectiveTracker = FindObjectOfType<ObjectiveTracker>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectiveBools.ObjectivesCompleted[4] = true;
            objectiveTracker.ObjectiveCheck();
        }
    }
}
