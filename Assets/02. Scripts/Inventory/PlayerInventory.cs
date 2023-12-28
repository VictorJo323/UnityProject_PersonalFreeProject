using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventorySO inventory;
    
    void Start()
    {
        
    }

    public void AddItemToInventory(ItemSO item)
    {
        inventory.AddItem(item);
        // �κ��丮 UI ������Ʈ
    }

    public void RemoveItemFromInventory(ItemSO item)
    {
        inventory.RemoveItem(item);
        // �κ��丮 UI ������Ʈ
    }
}
