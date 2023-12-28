using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public StatHandler statHandler;

    private Dictionary<ItemType, ItemSO> equippedItems = new Dictionary<ItemType, ItemSO>();
    private ItemSO equippedAcc1;
    private ItemSO equippedAcc2;

    public void EquipItem(ItemSO item)
    {
        if (item.type == ItemType.Accessory)
        {
            EquipAccessory(item);
            return;
        }

        if (equippedItems.ContainsKey(item.type))
        {
            // 기존 아이템 탈착
            UnequipItem(equippedItems[item.type]);
        }
        // 새 아이템 장착
        equippedItems[item.type] = item;
        statHandler.IncreaseStat(item);
        inventoryUI.UpdateUI();
        UpdateEquipmentUI();
    }

    public void UnequipItem(ItemSO item)
    {
        if (item == null || !equippedItems.ContainsKey(item.type))
        {
            return;
        }

        statHandler.DecreaseStat(item);
        equippedItems[item.type] = null;
        inventoryUI.UpdateUI();
        UpdateEquipmentUI();
    }

    public void EquipAccessory(ItemSO accessory)
    {
        if (equippedAcc1 == null)
        {
            EquipAccessoryInSlot(accessory, 1);
        }
        else if (equippedAcc2 == null)
        {
            EquipAccessoryInSlot(accessory, 2);
        }
        else
        {
            UnequipAccessory(1); // 선택적으로 1번 슬롯을 해제하고 새 악세사리를 장착
            EquipAccessoryInSlot(accessory, 1);
        }
    }

    public void EquipAccessoryInSlot(ItemSO accessory, int slotNumber)
    {

        if (slotNumber == 1)
        {

            if (equippedAcc1 != null)
            {

                statHandler.DecreaseStat(equippedAcc1); // 기존 악세사리 스탯 감소
            }
            equippedAcc1 = accessory;
            statHandler.IncreaseStat(accessory); // 새 악세사리 스탯 증가
        }
        else if (slotNumber == 2)
        {

            if (equippedAcc2 != null)
            {

                statHandler.DecreaseStat(equippedAcc2); 
            }
            equippedAcc2 = accessory;
            statHandler.IncreaseStat(accessory);
        }
        inventoryUI.UpdateUI();
        UpdateEquipmentUI();
    }

    public void EquipAccessoryToSlot1()
    {
        ItemSO selectedItem = inventoryUI.GetSelectedAccessory();
        if (selectedItem != null && selectedItem.type == ItemType.Accessory)
        {
            EquipAccessoryInSlot(selectedItem, 1);
        }
        inventoryUI.UpdateUI();
        UpdateEquipmentUI();

    }
    public void EquipAccessoryToSlot2()
    {
        ItemSO selectedItem = inventoryUI.GetSelectedAccessory();
        if (selectedItem != null && selectedItem.type == ItemType.Accessory)
        {
            EquipAccessoryInSlot(selectedItem, 2);
        }
        inventoryUI.UpdateUI();
        UpdateEquipmentUI();
    }

    public void UnequipAccessory(int slotNumber)
    {
        if (slotNumber == 1 && equippedAcc1 != null)
        {
            statHandler.DecreaseStat(equippedAcc1);
            equippedAcc1 = null;
        }
        else if (slotNumber == 2 && equippedAcc2 != null)
        {
            statHandler.DecreaseStat(equippedAcc2);
            equippedAcc2 = null;
        }
    }

    public void UnequipAccessory(ItemSO accessory)
    {
        if (accessory == null)
        {
            return;
        }

        if (equippedAcc1 == accessory)
        {
            UnequipAccessory(1);
        }
        else if (equippedAcc2 == accessory)
        {
            UnequipAccessory(2);
        }
    }

    public bool IsItemEquipped(ItemSO item)
    {
        if (item.type == ItemType.Accessory)
        {
            return item == equippedAcc1 || item == equippedAcc2;
        }
        return equippedItems.ContainsValue(item);
    }

    public void UpdateEquipmentUI()
    {
        inventoryUI.UpdateEquipmentPanel(equippedItems, equippedAcc1, equippedAcc2);
    }
}