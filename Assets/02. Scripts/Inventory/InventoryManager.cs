using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject consumablePanel;
    public GameObject headPanel;
    public GameObject armsPanel;
    public GameObject bodyPanel;
    public GameObject accPanel;

    private GameObject activePanel;


    public void OpenWindow(ItemType itemType)
    { 
        if(activePanel != null)
        {
            activePanel.SetActive(false);
        }

        switch(itemType)
        {
            case ItemType.Consumable:
                activePanel = consumablePanel;
                break;
            case ItemType.Head:
                activePanel = headPanel;
                break;
            case ItemType.Weapon:
                activePanel = armsPanel;
                break;
            case ItemType.Armor:
                activePanel = bodyPanel;
                break;
            case ItemType.Accessory:
                activePanel = accPanel;
                break;
        }

        if(activePanel != null)
        {
            activePanel.SetActive(true);
        }    
    }

    public void OpenConsumablePanel()
    {
        OpenWindow(ItemType.Consumable);
    }
    public void OpenHeadPanel()
    {
        OpenWindow(ItemType.Head);
    }
    public void OpenArmsPanel()
    {
        OpenWindow(ItemType.Weapon);
    }
    public void OpenBodyPanel()
    {
        OpenWindow(ItemType.Armor);
    }
    public void OpenAccPanel()
    {
        OpenWindow(ItemType.Accessory);
    }
}
