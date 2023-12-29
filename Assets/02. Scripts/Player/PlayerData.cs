using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public PlayerCharacterSO stats;
    public InventorySO inventory;
    public SkillsetSO basicAttack;
    public SkillsetSO skills;
    public Player player;
}
