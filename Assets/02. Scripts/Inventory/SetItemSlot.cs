using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetItemSlot : MonoBehaviour
{
    public Image itemIcon;
    public GameObject equipMarker;
    public ItemSO itemData;
    private InventoryUI inventoryUI;

    public void Setup(ItemSO item, InventoryUI ui)
    {
        itemData = item;
        inventoryUI = ui;
        itemIcon.sprite = item.itemIcon;

        equipMarker.SetActive(ui.equipmentManager.IsItemEquipped(item));
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        // InventoryUI의 아이템 이름과 설명을 업데이트하는 함수 호출
        inventoryUI.ClickItemSlot(itemData);
        inventoryUI.ClickAccessorySlot(itemData);
        equipMarker.SetActive(inventoryUI.equipmentManager.IsItemEquipped(itemData));
    }
    public void UpdateEquipStatus(bool isEquipped)
    {
        equipMarker.SetActive(isEquipped);
    }
}

