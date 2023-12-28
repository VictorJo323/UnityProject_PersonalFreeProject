using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject itemSlots;

    public TextMeshProUGUI itemNameText; // 아이템 이름을 표시할 Text 컴포넌트
    public TextMeshProUGUI itemDescriptionText; // 아이템 설명을 표시할 Text 컴포넌트

    public EquipmentManager equipmentManager;
    private ItemSO currentItem;
    public InventorySO playerInventory;
    private ItemSO selectedAccessory;

    public TextMeshProUGUI headText;
    public TextMeshProUGUI weaponText;
    public TextMeshProUGUI armorText;
    public TextMeshProUGUI acc1Text;
    public TextMeshProUGUI acc2Text;

    public Image headIcon;
    public Image weaponIcon;
    public Image armorIcon;
    public Image acc1;
    public Image acc2;

    public void ShowCategoryItems(ItemType itemType)
    {
        if (playerInventory == null || playerInventory.items == null)
        {
            Debug.LogError("PlayerInventory or its items list is null.");
            return;
        }
        List<ItemSO> itemsToShow = playerInventory.items.FindAll(item => item.type == itemType);
        UpdateInventoryPanel(itemsToShow);
    }

    public void ShowConsumables()
    {
        ShowCategoryItems(ItemType.Consumable);
    }

    public void ShowHeads()
    {
        ShowCategoryItems(ItemType.Head);
    }

    public void ShowWeapons()
    {
        ShowCategoryItems(ItemType.Weapon);
    }

    public void ShowArmors()
    {
        ShowCategoryItems(ItemType.Armor);
    }

    public void ShowAccs()
    {
        ShowCategoryItems(ItemType.Accessory);
    }


    private void UpdateInventoryPanel(List<ItemSO> showItems)
    {
        Debug.Log($"Updating inventory panel with {showItems.Count} items.");
        Debug.Log("Number of items to show: " + showItems.Count);

        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (ItemSO item in showItems)
        {
            GameObject slotObject = Instantiate(itemSlots, inventoryPanel.transform);
            SetItemSlot itemSlot = slotObject.GetComponent<SetItemSlot>();
            itemSlot.Setup(item, this);
        }
    }

    public void ClickItemSlot(ItemSO item)
    {
        currentItem = item;
        itemNameText.text = item.itemName;
        itemDescriptionText.text = item.itemDescription;
    }


    public void EquipSelectedItem()
    {
        if(currentItem!=null)
        {
            equipmentManager.EquipItem(currentItem);
        }    
    }

    public void UnequipSelectedItem()
    {
        if(currentItem!= null)
        {
            equipmentManager.UnequipItem(currentItem);
            currentItem = null;
        }
    }

    public void ClickAccessorySlot(ItemSO accessory)
    {
        selectedAccessory = accessory;
        itemNameText.text = accessory.itemName;
        itemDescriptionText.text = accessory.itemDescription;
    }

    public ItemSO GetSelectedAccessory()
    {
        return selectedAccessory;
    }
    public void UpdateUI()
    {
        foreach(Transform slots in inventoryPanel.transform)
        {
            SetItemSlot slot = slots.GetComponent<SetItemSlot>();
            if(slot!=null)
            {
                slot.UpdateEquipStatus(equipmentManager.IsItemEquipped(slot.itemData));
            }
        }
    }

    public void UnequipSelectedAcc()
    {
        if (selectedAccessory != null)
        {
            equipmentManager.UnequipAccessory(selectedAccessory);
            selectedAccessory = null;
            UpdateUI();
            equipmentManager.UpdateEquipmentUI();
        }
    }

    public void UpdateEquipmentPanel(Dictionary<ItemType, ItemSO> equippedItems, ItemSO equippedAcc1, ItemSO equippedAcc2)
    {
        if (equippedItems.TryGetValue(ItemType.Head, out ItemSO head))
        {
            headIcon.sprite = head.itemIcon;
            headText.text = head.itemName;
        }
        else
        {
            armorText.text = "NONE";
        }
        if (equippedItems.TryGetValue(ItemType.Weapon, out ItemSO weapon))
        {
            weaponIcon.sprite = weapon.itemIcon;
            weaponText.text = weapon.itemName;
        }
        else
        {
            weaponText.text = "NONE";
        }

        if (equippedItems.TryGetValue(ItemType.Armor, out ItemSO armor))
        {
            armorIcon.sprite = armor.itemIcon;
            armorText.text = armor.itemName;
        }
        else
        {
            armorText.text = "NONE";
        }

        if (equippedAcc1 != null)
        {
            acc1.sprite = equippedAcc1.itemIcon; 
            acc1Text.text = equippedAcc1.itemName;
        }
        else
        {
            acc1Text.text = "NONE";
        }

        if (equippedAcc2 != null)
        {
            acc2.sprite = equippedAcc2.itemIcon;
            acc2Text.text = equippedAcc2.itemName;
        }
        else
        {
            acc2Text.text = "NONE";
        }
    }
}
