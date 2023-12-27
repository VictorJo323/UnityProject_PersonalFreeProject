using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Head,
    Weapon,
    Armor,
    Accessory,
    Consumable,
}

[CreateAssetMenu(fileName = "Item_", menuName = "Player/Item", order = 2)]
public class ItemSO : ScriptableObject
{
    public ItemType type;
    public int plusHP;
    public int plusMP;
    public int plusAtk;
    public int plusDef;
    public int plusFoc;
    public int plusCrit;
    public int plusAgi;
}
