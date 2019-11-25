using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class SpeechTracker : MonoBehaviour
{
    public GravEngineerLines gravEngineerLines;
    public Text currentLine;
    public GameObject currentlineBox;
    public GameObject speechUI;
    public GameObject[] spawnLocations;
    public GameObject speechTrigger; 
    string story;

    // Start is called before the first frame update

    private void Start()
    {
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           
            if(gravEngineerLines.LineBool[gravEngineerLines.locationNumber] == false && gravEngineerLines.isTyping == false)
            {
                currentLine.text = gravEngineerLines.GEngiLines[gravEngineerLines.locationNumber];
                speechUI.gameObject.GetComponent<SpeechFadeIn>().fadein();
                gravEngineerLines.LineBool[gravEngineerLines.locationNumber] = true;

                StartTyping(); 
            }
        }

    }
    public void StartTyping()
    {
        story = currentLine.text;
        currentLine.text = "";

        // TODO: add optional delay when to start
        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        gravEngineerLines.isTyping = true; 
        foreach (char c in story)
        {
            currentLine.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        gravEngineerLines.locationNumber++;
        spawnLocations[gravEngineerLines.locationNumber] = Instantiate(speechTrigger, spawnLocations[gravEngineerLines.locationNumber].transform.position, Quaternion.identity) as GameObject; 
        gravEngineerLines.isTyping = false;
        speechUI.gameObject.GetComponent<SpeechFadeIn>().fadeout();
        Object.Destroy(gameObject);
        
    }
}
