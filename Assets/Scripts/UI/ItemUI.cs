using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image itemImage;
    public GameObject selectedImage;

    public TextMeshProUGUI itemName;

    public CustomizationItem itemData;
    public void SetItem()
    {
        itemName.text = itemData.name;
        itemImage.sprite = itemData.uiSprite;
        selectedImage.SetActive(EventManager.CheckIfItemUsing(itemData.id));
    }

    private void OnEnable()
    {
        EventManager.ItemClicked += ItemClicked;
    }

    private void OnDisable()
    {
        EventManager.ItemClicked -= ItemClicked;
    }

    private void ItemClicked(CustomizationItem data)
    {
        if (data!=itemData)
            selectedImage.SetActive(false);
            
    }

    public void ItemClicked()
    {
        EventManager.ItemClicked(itemData);
        selectedImage.SetActive(true);
    }
}
