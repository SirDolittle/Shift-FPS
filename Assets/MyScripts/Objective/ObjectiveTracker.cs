using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTracker : MonoBehaviour
{
    public string[] MainObjectives;
    public string[] SideObjectives;
    public GameObject[] MainMarkers;
    public GameObject[] SideMarkers;
    public GameObject MainMarker;
    public GameObject SideMarker;
    private GameObject currentSideMarker;
    private GameObject currentMainMarker;
    public Text currentMainObjective;
    public Text currentSideObjective;
    public ObjectiveBools objectivebools; 
    // Start is called before the first frame update
    void Start()
    {
        currentMainObjective.text = MainObjectives[0];
        currentSideObjective.text = SideObjectives[0];
        currentSideMarker = Instantiate(SideMarker, SideMarkers[0].transform.position, Quaternion.identity);
        currentMainMarker = Instantiate(MainMarker, MainMarkers[0].transform.position, Quaternion.identity);

    }

    public void ObjectiveCheck()
    {
        if (objectivebools.ObjectivesCompleted[0] == true)
        {
            currentSideObjective.text = SideObjectives[1];
            currentSideMarker.transform.position = SideMarkers[1].transform.position; 
        }
        if (objectivebools.ObjectivesCompleted[1] == true)
        {
            currentSideObjective.text = SideObjectives[2];
            currentSideMarker.transform.position = SideMarkers[2].transform.position;
        }
        if (objectivebools.ObjectivesCompleted[2] == true)
        {
            currentSideObjective.text = SideObjectives[3];
            currentSideMarker.transform.position = SideMarkers[3].transform.position;
        }
        if (objectivebools.ObjectivesCompleted[3] == true)
        {
            currentSideObjective.text = SideObjectives[4];
            currentSideMarker.transform.position = SideMarkers[4].transform.position;
        }
        if (objectivebools.ObjectivesCompleted[4] == true)
        {
            currentMainObjective.text = MainObjectives[1];
            currentMainMarker.transform.position = MainMarkers[1].transform.position;
            currentSideObjective.text = SideObjectives[5];
            currentSideMarker.transform.position = SideMarkers[5].transform.position;
        }
        if(objectivebools.ObjectivesCompleted[5] == true)
        {
            currentSideObjective.text = SideObjectives[6];
            currentSideMarker.transform.position = SideMarkers[6].transform.position;
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
