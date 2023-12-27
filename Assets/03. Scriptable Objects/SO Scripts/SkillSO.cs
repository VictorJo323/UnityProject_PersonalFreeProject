using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StanceType
{
    Attack,
    Counter,
    Throw,
    Assist
}

[CreateAssetMenu(fileName = "Skill_", menuName = "Player/Skills", order = 1)]
public class SkillSO : ScriptableObject
{
    public string skillName;
    public string description;
    public int mpUse;
    public float constance;
    public StanceType stanceType;
}
