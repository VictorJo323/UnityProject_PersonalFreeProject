using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWindowManager : MonoBehaviour
{
    public GameObject statusWindow;
    public GameObject inventoryWindow;
    public GameObject skillsWindow;
    public GameObject settingWindow;

    private GameObject activePanel;

    private void Start()
    {
        OpenPanel(statusWindow);
    }

    private void OpenPanel(GameObject openPanel)
    {
        if(activePanel!=null)
        {
            activePanel.SetActive(false);
        }
        activePanel = openPanel;
        activePanel.SetActive(true);
    }

    public void OpenStatus()
    {
        OpenPanel(statusWindow);
    }

    public void OpenInventory()
    {
        OpenPanel(inventoryWindow);
    }

    public void OpenSkills()
    {
        OpenPanel(skillsWindow);
    }

    public void OpenSetting()
    {
        OpenPanel(settingWindow);
    }
}
