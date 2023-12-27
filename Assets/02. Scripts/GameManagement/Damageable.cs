using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public static int CalculateDamage(SkillSO attack, SkillSO defence, IStatusData attacker, IStatusData Defender)
    {
        float damageMultiplier = 1f;
        int baseStat = 0;
        
        switch(attack.stanceType)
        {
            case StanceType.Attack:
                baseStat = (int)(attacker.Atk * attack.constance);
                switch(defence.stanceType)
                {
                    case StanceType.Attack:
                        damageMultiplier = 1f;
                        break;

                    case StanceType.Counter:
                        damageMultiplier = 0.5f;
                        break;

                    case StanceType.Throw:
                        damageMultiplier = 1.5f;
                        break;

                    case StanceType.Assist:
                        break;
                }
                break;

            case StanceType.Counter:
                baseStat = (int)(attacker.Def * attack.constance);
                switch (defence.stanceType)
                {
                    case StanceType.Attack:
                        damageMultiplier = 2f;
                        break;

                    case StanceType.Counter:
                        damageMultiplier = 0f;
                        break;

                    case StanceType.Throw:
                        damageMultiplier = 0.5f;
                        break;

                    case StanceType.Assist:
                        break;
                }
                break;

            case StanceType.Throw:
                baseStat = (int)(attacker.Foc * attack.constance);
                switch (defence.stanceType)
                {
                    case StanceType.Attack:
                        damageMultiplier = 0.5f;
                        break;

                    case StanceType.Counter:
                        damageMultiplier = 2f;
                        break;

                    case StanceType.Throw:
                        damageMultiplier = 0f;
                        break;

                    case StanceType.Assist:
                        break;
                }
                break;
        }
        int damage = (int)(baseStat * damageMultiplier - Defender.Def);
        if(Random.value < (attacker.Crit/100f))
        {
            damage = (int)(damage * 1.5f);
        }

        if (damage < 0)
        {
            damage = 0;
        }

        return damage;
    }
}
