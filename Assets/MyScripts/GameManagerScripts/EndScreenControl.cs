using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreenControl : MonoBehaviour
{
    public void RestartScene()
    {
       
        SceneManager.LoadScene("Level GreyBox");
        Debug.Log("Scene Called");
        Physics.gravity = new Vector3(0, -9.8f, 0);
    }
}
