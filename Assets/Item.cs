using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Image itemImage;

    public TextMeshProUGUI itemName;

    public Customization itemData;
    public void SetItem()
    {
        itemName.text = itemData.name;
        itemImage.sprite = itemData.sprite;
    }

    public void ItemClicked()
    {
        EventManager.ItemClicked(itemData);
    }
}
