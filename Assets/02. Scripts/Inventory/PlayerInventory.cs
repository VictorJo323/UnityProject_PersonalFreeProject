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
        // 인벤토리 UI 업데이트
    }

    public void RemoveItemFromInventory(ItemSO item)
    {
        inventory.RemoveItem(item);
        // 인벤토리 UI 업데이트
    }
}
