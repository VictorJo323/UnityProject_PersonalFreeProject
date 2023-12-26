using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
    public void StartToMainScene()
    {
        SceneManager.LoadScene("MainScene"); 
    }

    public void MainToStartScene()
    {
        SceneManager.LoadScene("StartScene"); 
    }
}
