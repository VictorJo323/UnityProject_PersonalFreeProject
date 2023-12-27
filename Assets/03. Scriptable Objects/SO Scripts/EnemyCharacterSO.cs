using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy_", menuName = "Enemy/Character", order = 0)]
public class EnemyCharacterSO : ScriptableObject

{
    public int level;
    public int str;
    public int def;
    public int foc;
    public int hp;
    public int mp;

    public int goldDrop;
    public int expDrop;
}
