using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIHandler : MonoBehaviour
{
    public GameObject buttons;
    private TextMeshProUGUI skillNamePlace;

    public Transform attackPanel;
    public Transform skillPanel;

    private Player player;


    private void Start()
    {
        PlayerDataManager playerDataManager = PlayerDataManager.Instance;

        if (playerDataManager != null)
        {
            PlayerData playerData = playerDataManager.playerData;
            if (playerData != null)
            {
                player = playerData.player; // player 변수를 playerData에서 가져옵니다.

                Debug.Log($"Basic Attack: {player.basicAttack}");
                Debug.Log($"Skills: {player.skills}");

                Debug.Log("Player Data is not null");
                CreateAttackButtons(playerData.basicAttack);
                CreateSkillButtons(playerData.skills);
            }
        }
    }

    public void CreateAttackButtons(SkillsetSO attackSet)
    {
        if (attackSet == null)
        {
            Debug.LogError("AttackSet is null.");
            return;
        }

        foreach (SkillSO skill in attackSet.skills)
        {
            GameObject button = Instantiate(buttons, attackPanel);
            skillNamePlace = button.GetComponentInChildren<TextMeshProUGUI>();
            skillNamePlace.text = skill.skillName;
            button.GetComponent<Button>().onClick.AddListener(() => player.Select(skill));
        }
    }

    public void CreateSkillButtons(SkillsetSO skillSet)
    {
        if (skillSet == null)
        {
            Debug.LogError("SkillSet is null.");
            return;
        }
        foreach (SkillSO skill in skillSet.GetSkills())
        {
            GameObject button = Instantiate(buttons, skillPanel);
            skillNamePlace = button.GetComponentInChildren<TextMeshProUGUI>();
            skillNamePlace.text = skill.skillName;
            button.GetComponent<Button>().onClick.AddListener(() => player.Select(skill));
        }
    }

    private void SelectAction(SkillSO skill)
    {
        player.Select(skill);
    }
}
