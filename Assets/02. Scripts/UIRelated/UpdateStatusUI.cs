using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateStatusUI : MonoBehaviour
{
    public PlayerCharacterSO playerCharacter;


    [Header ("Character Info")]
    public TextMeshProUGUI charNameField;
    public TextMeshProUGUI charDescriptionField;
    
    [Header("Status")]
    public TextMeshProUGUI hpIndicatorField;
    public TextMeshProUGUI mpIndicatorField;
    public TextMeshProUGUI atkIndicatorField;
    public TextMeshProUGUI defIndicatorField;
    public TextMeshProUGUI focIndicatorField;
    public TextMeshProUGUI critIndicatorField;
    public TextMeshProUGUI agiIndicatorField;

    [Header("Equipment Field")]
    public Sprite headItem;
    public Sprite weaponItem;
    public Sprite armorItem;
    public Sprite accSlot1;
    public Sprite accSlot2;

    public TextMeshProUGUI itemDescription1;
    public TextMeshProUGUI itemDescription2;
    public TextMeshProUGUI itemDescription3;
    public TextMeshProUGUI itemDescription4;
    public TextMeshProUGUI itemDescription5;

    public void UpdateStatusUIText()
    {
        charNameField.text = playerCharacter.charName;
        charDescriptionField.text = playerCharacter.charDescription;

    }

}
