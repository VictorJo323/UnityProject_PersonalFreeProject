using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalStats : IStatusData
{
    public string Name { get; private set; }

    public int Hp { get; private set; }

    public int Mp { get; private set; }

    public int Atk { get; private set; }

    public int Def { get; private set; }

    public int Foc { get; private set; }

    public float Crit { get; private set; }

    public float Agi { get; private set; }

    public FinalStats(StatHandler handler)
    {
        Hp = handler.curHP;
        Mp = handler.curMP;
        Atk = handler.baseAtk + handler.modAtk;
        Def = handler.baseDef + handler.modDef;
        Foc = handler.baseFoc + handler.modFoc;
        Crit = handler.baseCrit + handler.modCrit;
        Agi = handler.baseAgi + handler.modAgi;
    }
}
