using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TabsManager : MonoBehaviour
{
    public GameObject tabPrefab;
    public List<Tab> tabs;


    [Button]
    public void CreateTabs()
    {
        foreach (var tab in tabs)
        {
#if UNITY_EDITOR
            DestroyImmediate(tab.gameObject);
#else
            Destroy(tab.gameObject);
#endif
        }

        tabs.Clear();
        var myEnumMemberCount = Enum.GetNames(typeof(CustomizationCategories)).Length;

        for (int i = 0; i < myEnumMemberCount; i++)
        {
            var tab = PrefabUtility.InstantiatePrefab(tabPrefab, transform).GetComponent<Tab>();
            tab.category = (CustomizationCategories)i;
            tabs.Add(tab);
            tab.SetTab();
        }
    }
}