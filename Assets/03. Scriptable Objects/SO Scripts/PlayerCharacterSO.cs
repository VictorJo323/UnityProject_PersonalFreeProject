using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "Player/Character", order =0)]
public class PlayerCharacterSO : ScriptableObject

{
    public int level;
    public int str;
    public int def;
    public int foc;
    public int hp;
    public int mp;

}
