using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyCharacterSO stats;
    private StatHandler handler;

    public void Initialize(EnemyCharacterSO data)
    {
        stats = data;
        handler = GetComponent<StatHandler>();
        if (handler != null)
        {
            handler.Initialize(stats);
        }
    }

    public SkillSO ChooseAction()
    {
        if (stats.skills.Count == 0) 
        {
            return null;
        }
        return stats.skills[Random.Range(0, stats.skills.Count)];
    }
}
