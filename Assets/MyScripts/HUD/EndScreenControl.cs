using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreenControl : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene("TestScene");
        Debug.Log("Scene Called");
    }
}
