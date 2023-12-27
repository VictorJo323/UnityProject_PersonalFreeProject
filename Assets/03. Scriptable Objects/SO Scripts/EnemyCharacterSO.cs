using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy_", menuName = "Enemy/Character", order = 0)]
public class EnemyCharacterSO : ScriptableObject, IStatusData

{
    public string monsterName;
    public string monsterDescription;
    public Sprite monsterImage;
    public int level;
    public int atk;
    public int def;
    public int foc;
    public int hp;
    public int mp;
    public float crit;
    public float agi;

    public int goldDrop;
    public int expDrop;

    [Header("Skill List")]
    public List<SkillSO> skills;

    public string Name => monsterName;

    public int Hp => hp;

    public int Atk => atk;

    public int Def => def;

    public int Foc => foc;

    public float Crit => crit;

    public float Agi => agi;
}
