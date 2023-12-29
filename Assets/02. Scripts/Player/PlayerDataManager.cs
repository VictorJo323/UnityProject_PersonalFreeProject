using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance { get; private set; }

    public PlayerData playerData;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            playerData = new PlayerData();
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                playerData.player = playerObject.GetComponent<Player>();
            }
        }
    }

    public void UpdatePlayerData(StatHandler statHandler, InventorySO inventory, SkillsetSO basicAttack, SkillsetSO skills)
    {
        playerData.stats = statHandler.GetCurrentStats(); 
        playerData.inventory = inventory; 
        playerData.basicAttack = basicAttack; 
        playerData.skills = skills; 
    }
}
