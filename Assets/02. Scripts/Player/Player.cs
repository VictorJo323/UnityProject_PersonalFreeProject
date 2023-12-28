using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCharacterSO stats;
    public InventorySO inventory;
    public SkillsetSO basicAttack;
    public SkillsetSO skills;
    private StatHandler statHandler;

    private void Start()
    {
        statHandler = GetComponent<StatHandler>();
        if(statHandler != null)
        {
            statHandler.Initialize(stats);
        }
        Vector2 savedPosition = GameManager.Instance.LoadPosition();
        if(savedPosition != Vector2.zero)
        {
            transform.position = savedPosition;
        }
        else
        {
            transform.position = Vector2.zero;
        }
    }

    public void SavePosition()
    {
        GameManager.Instance.SavePosition(transform.position);
    }
}
