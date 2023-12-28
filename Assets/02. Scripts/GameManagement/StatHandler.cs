using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    private int maxHP;
    private int maxMP;
    private int curHP;
    private int curMP;

    private int baseAtk;
    private int baseDef;
    private int baseFoc;
    private float baseCrit;
    private float baseAgi;
    private int modAtk = 0;
    private int modDef = 0;
    private int modFoc = 0;
    private float modCrit = 0;
    private float modAgi = 0;



    public TextMeshProUGUI statIndicator;

    public void Initialize(IStatusData charData)
    {
        maxHP = charData.Hp;
        maxMP = charData.Mp;
        curHP = maxHP;
        curMP = maxMP;
        baseAtk = charData.Atk;
        baseDef = charData.Def;
        baseFoc = charData.Foc;
        baseAgi = charData.Agi;
        baseCrit = charData.Crit;

        UpdateStat();
    }

    public void UpdateStat()
    {
        statIndicator.text = $"{curHP}/{maxHP}\n{curMP}/{maxMP}\n{baseAtk+modAtk} ({baseAtk} + {modAtk})\n{baseDef+modDef} ({baseDef} + {modDef})\n{baseFoc+modFoc} ({baseFoc} + {modFoc})\n{baseCrit+modCrit} %\n{baseAgi+modAgi} %";
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        curHP = Mathf.Max(curHP, 0);
    }

    public void UseMP(int usedMP)
    {
        curMP -= usedMP;
        curMP = Mathf.Max(curMP, 0);
    }

    public void IncreaseStat(ItemSO item)
    {
        curHP += item.plusHP;
        curMP += item.plusMP;
        modAtk += item.plusAtk;
        modDef += item.plusDef;
        modFoc += item.plusFoc;
        modAgi += item.plusAgi;
        modCrit += item.plusCrit;

        UpdateStat();

    }

    public void DecreaseStat(ItemSO item)
    {
        curHP -= item.plusHP;
        curMP -= item.plusMP;
        modAtk -= item.plusAtk;
        modDef -= item.plusDef;
        modFoc -= item.plusFoc;
        modAgi -= item.plusAgi;
        modCrit -= item.plusCrit;

        UpdateStat();

    }
}
