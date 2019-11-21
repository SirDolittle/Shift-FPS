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
           /* if(gravEngineerLines.LineBool[0] == false && gravEngineerLines.isTyping == false)
            {
                currentLine.text = gravEngineerLines.GEngiLines[0];
                gravEngineerLines.LineBool[0] = true;
                speechUI.gameObject.GetComponent<SpeechFadeIn>().fadein();
                StartTyping();
                spawnLocations[0] = Instantiate(speechTrigger, spawnLocations[0].transform.position, Quaternion.identity) as GameObject;
            }
            else 
            if (gravEngineerLines.LineBool[1] == false && gravEngineerLines.isTyping == false)
            {
                currentLine.text = gravEngineerLines.GEngiLines[1];
                speechUI.gameObject.GetComponent<SpeechFadeIn>().fadein(); 
                gravEngineerLines.LineBool[1] = true;
 
                StartTyping();
                
            }
            else 
            if (gravEngineerLines.LineBool[2] == false && gravEngineerLines.isTyping == false)
            {
                currentLine.text = gravEngineerLines.GEngiLines[2];
                speechUI.gameObject.GetComponent<SpeechFadeIn>().fadein();
                gravEngineerLines.LineBool[2] = true;
                StartTyping();
            }
            else
            if (gravEngineerLines.LineBool[3] == false && gravEngineerLines.isTyping == false)
            {
                currentLine.text = gravEngineerLines.GEngiLines[3];
                speechUI.gameObject.GetComponent<SpeechFadeIn>().fadein();
                gravEngineerLines.LineBool[3] = true;
                StartTyping();
            }
            else
            if (gravEngineerLines.LineBool[4] == false && gravEngineerLines.isTyping == false)
            {
                currentLine.text = gravEngineerLines.GEngiLines[4];
                speechUI.gameObject.GetComponent<SpeechFadeIn>().fadein();
                gravEngineerLines.LineBool[4] = true;
                StartTyping();
            }
            else
            if (gravEngineerLines.LineBool[4] == false && gravEngineerLines.isTyping == false)
            {
                currentLine.text = gravEngineerLines.GEngiLines[4];
                speechUI.gameObject.GetComponent<SpeechFadeIn>().fadein();
                gravEngineerLines.LineBool[4] = true;
                StartTyping();
            }
            else
            if (gravEngineerLines.LineBool[5] == false && gravEngineerLines.isTyping == false)
            {
                currentLine.text = gravEngineerLines.GEngiLines[4];
                speechUI.gameObject.GetComponent<SpeechFadeIn>().fadein();
                gravEngineerLines.LineBool[5] = true;
                StartTyping();
            }
            */
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
