using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Image itemImage;
    public GameObject choosenImage;

    public TextMeshProUGUI itemName;

    public Customization itemData;
    public void SetItem()
    {
        itemName.text = itemData.name;
        itemImage.sprite = itemData.sprite;
        choosenImage.SetActive(EventManager.CheckIfItemUsing(itemData.id));
    }

    private void OnEnable()
    {
        EventManager.ItemClicked += ItemClicked;
    }

    private void OnDisable()
    {
        EventManager.ItemClicked -= ItemClicked;
    }

    private void ItemClicked(Customization data)
    {
        if (data!=itemData)
        {
            choosenImage.SetActive(false);

        }
    }

    public void ItemClicked()
    {
        EventManager.ItemClicked(itemData);
        choosenImage.SetActive(true);
    }
}
