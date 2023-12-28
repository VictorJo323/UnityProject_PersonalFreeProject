using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewInventory", menuName = "Player/Inventory", order = 3)]
public class InventorySO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();
    public void AddItem(ItemSO item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
        }
    }

    public void RemoveItem(ItemSO item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
    }
}
