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

[CreateAssetMenu(fileName = "Item_", menuName = "Item/Item", order = 0)]
public class ItemSO : ScriptableObject
{
    public ItemType type;
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
    public int plusHP;
    public int plusMP;
    public int plusAtk;
    public int plusDef;
    public int plusFoc;
    public int plusCrit;
    public int plusAgi;
    public int price;
}
