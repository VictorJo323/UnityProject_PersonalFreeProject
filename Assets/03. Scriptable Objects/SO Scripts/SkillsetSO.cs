using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkillSet", menuName = "Player/SkillSet", order =4)]

public class SkillsetSO : ScriptableObject
{
    public List<SkillSO> skills = new List<SkillSO>();

    public void AddSkill(SkillSO skill)
    {
        if (!skills.Contains(skill))
        {
            skills.Add(skill);
        }
    }

    public void RemoveSkill(SkillSO skill)
    {
        if (skills.Contains(skill))
        {
            skills.Remove(skill);
        }
    }
}
