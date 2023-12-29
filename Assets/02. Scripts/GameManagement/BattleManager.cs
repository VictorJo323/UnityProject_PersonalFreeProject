
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public EnemyCharacterSO[] enemies;
    public Transform enemyPosition;
    public GameObject enemyInfo;

    public Player player;
    public Enemy enemy;

    private void Start()
    {
        SpawnRandomEnemy();
    }

    private void SpawnRandomEnemy()
    {
        EnemyCharacterSO enemyToShow = enemies[Random.Range(0, enemies.Length)];
        GameObject enemyCreated = Instantiate(enemyInfo, enemyPosition.position, Quaternion.identity);
    }


    public void ClickDecideButton()
    {
        SkillSO playerAction = player.ChooseAction();
        SkillSO enemyAction = enemy.ChooseAction();

        PerformAttack(playerAction, enemyAction, player.gameObject, enemy.gameObject);
    }


    public void PerformAttack(SkillSO attackSkill, SkillSO defenceSkill, GameObject attacker, GameObject defender)
    {
        IStatusData attackerData = attacker.GetComponent<StatHandler>().GetFinalStats();
        IStatusData defenderData = defender.GetComponent<StatHandler>().GetFinalStats();;

        int damage = Damageable.CalculateDamage(attackSkill, defenceSkill, attackerData, defenderData);

        StatHandler defenderStatHandler = defender.GetComponent<StatHandler>();
        if (defenderStatHandler != null)
        {
            defenderStatHandler.TakeDamage(damage);
        }
    }
}
