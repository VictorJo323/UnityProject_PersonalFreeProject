using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Vector2 playerPosition;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePosition(Vector2 position)
    {
        Debug.Log(position);
        playerPosition = position;
    }

    public Vector2 LoadPosition()
    {
        return playerPosition;
    }
}
