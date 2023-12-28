using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
    public void ToMainScene()
    {
        SceneManager.LoadScene("MainScene"); 
    }

    public void ToStartScene()
    {
        SceneManager.LoadScene("StartScene"); 
    }

    public void Run()
    {
        Vector2 savedPosition = GameManager.Instance.LoadPosition();
        SceneManager.LoadScene("MainScene");

    }
}
