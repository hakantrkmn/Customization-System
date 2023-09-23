using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{

    public GameObject itemPrefab;

    public CustomizationData data;
    public List<Item> customizationItems;
    private void OnEnable()
    {
        EventManager.TabButtonClicked += TabButtonClicked;
    }

    private void OnDisable()
    {
        EventManager.TabButtonClicked -= TabButtonClicked;
    }

    [Button]
    private void TabButtonClicked(CustomizationCategories category)
    {

        foreach (var item in customizationItems)
        {
            DestroyImmediate(item.gameObject);
        }
        
        customizationItems.Clear();
        var allData = data.customizationList.Where(x => x.customizationCategory == category).ToList();

        foreach (var dat in allData)
        {
            var cloth = Instantiate(itemPrefab, transform);
            cloth.GetComponent<Item>().itemData = dat;
            customizationItems.Add(cloth.GetComponent<Item>());
            cloth.GetComponent<Item>().SetItem();
        }
    }
}
