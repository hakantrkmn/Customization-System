using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIItemsManager : MonoBehaviour
{

    public GameObject itemPrefab;

    public CustomizationData data;
    public List<ItemUI> customizationItems;
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
            item.gameObject.SetActive(true);
        }
        var allData = data.customizationList.Where(x => x.customizationCategory == category).ToList();

        if (allData.Count< customizationItems.Count)
        {
            for (int i = allData.Count; i < customizationItems.Count; i++)
            {
                customizationItems[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < allData.Count; i++)
            {
                var cloth = customizationItems[i];
                cloth.GetComponent<ItemUI>().itemData = allData[i];
                cloth.GetComponent<ItemUI>().SetItem();
            }
        }
        else if (allData.Count > customizationItems.Count)
        {

            for (int i = customizationItems.Count; i < allData.Count; i++)
            {
                var cloth = PrefabUtility.InstantiatePrefab(itemPrefab, transform) as GameObject;
                customizationItems.Add(cloth.GetComponent<ItemUI>());
            }
            for (int i = 0; i < allData.Count; i++)
            {
                var cloth = customizationItems[i];
                cloth.GetComponent<ItemUI>().itemData = allData[i];
                cloth.GetComponent<ItemUI>().SetItem();
            }
        }
        else
        {
            for (int i = 0; i < allData.Count; i++)
            {
                var cloth = customizationItems[i];
                cloth.GetComponent<ItemUI>().itemData = allData[i];
                cloth.GetComponent<ItemUI>().SetItem();
            }
        }
        
    }
}
