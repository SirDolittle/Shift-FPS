using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTracker : MonoBehaviour
{
    public string[] MainObjectives;
    public string[] SideObjectives;
    public Text currentMainObjective;
    public Text currentSideObjective;
    public ObjectiveBools objectivebools; 
    // Start is called before the first frame update
    void Start()
    {
        currentMainObjective.text = MainObjectives[0];
        currentSideObjective.text = SideObjectives[0]; 
    }

    public void ObjectiveCheck()
    {
        if (objectivebools.ObjectivesCompleted[0] == true)
        {
            currentSideObjective.text = SideObjectives[1];
        }
        if (objectivebools.ObjectivesCompleted[1] == true)
        {
            currentSideObjective.text = SideObjectives[2];
        }
        if (objectivebools.ObjectivesCompleted[2] == true)
        {
            currentSideObjective.text = SideObjectives[3];
        }
        if (objectivebools.ObjectivesCompleted[3] == true)
        {
            currentSideObjective.text = SideObjectives[4];
        }
        if (objectivebools.ObjectivesCompleted[4] == true)
        {
            currentMainObjective.text = MainObjectives[1];
            currentSideObjective.text = SideObjectives[5]; 
        }
        if(objectivebools.ObjectivesCompleted[5] == true)
        {
            currentSideObjective.text = SideObjectives[6];
        }
            
    }

    private void OnApplicationQuit()
    {
        objectivebools.ObjectivesCompleted[0] = false;
        objectivebools.ObjectivesCompleted[1] = false;
        objectivebools.ObjectivesCompleted[2] = false;
        objectivebools.ObjectivesCompleted[3] = false;
        objectivebools.ObjectivesCompleted[4] = false;
        objectivebools.ObjectivesCompleted[5] = false;
        objectivebools.ObjectivesCompleted[6] = false;
    }
}
