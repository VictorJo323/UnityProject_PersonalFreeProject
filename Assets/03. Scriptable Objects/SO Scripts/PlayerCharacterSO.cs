using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "Player/Character", order =0)]
public class PlayerCharacterSO : ScriptableObject, IStatusData

{
    public string charName;
    public string charDescription;
    public int level;
    public int atk;
    public int def;
    public int foc;
    public int hp;
    public int mp;
    public float crit;
    public float agi;

    public int initGold;
    private int expToLvUp = 100;

    [Header("Skill List")]
    public List<SkillSO> skills;

    public string Name => charName;

    public int Hp => hp;

    public int Atk => atk;

    public int Def => def;

    public int Foc => foc;

    public float Crit => crit;

    public float Agi => agi;
}
