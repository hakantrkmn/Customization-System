using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class UITexturesManager : MonoBehaviour
{
    public GameObject textureUIPrefab;

    public List<UIItemTexture> customizationTextures;

    private void OnEnable()
    {
        EventManager.TabButtonClicked += TabButtonClicked;
        EventManager.ItemClicked += ItemClicked;
    }

    private void TabButtonClicked(CustomizationCategories obj)
    {
        foreach (var item in customizationTextures)
        {
            item.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        EventManager.TabButtonClicked -= TabButtonClicked;
        EventManager.ItemClicked -= ItemClicked;
    }

    private void ItemClicked(CustomizationItem data)
    {
        foreach (var item in customizationTextures)
        {
            item.gameObject.SetActive(true);
        }

        if (data.textures.Count < customizationTextures.Count)
        {
            for (int i = data.textures.Count; i < customizationTextures.Count; i++)
            {
                customizationTextures[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < data.textures.Count; i++)
            {
                var texture = customizationTextures[i];

                texture.GetComponent<UIItemTexture>().itemData = data;
                texture.GetComponent<UIItemTexture>().SetItem(i);
            }
        }
        else if (data.textures.Count > customizationTextures.Count)
        {

            for (int i = customizationTextures.Count; i < data.textures.Count; i++)
            {
                var cloth = PrefabUtility.InstantiatePrefab(textureUIPrefab, transform) as GameObject;
                customizationTextures.Add(cloth.GetComponent<UIItemTexture>());
            }

            for (int i = 0; i < data.textures.Count; i++)
            {
                var texture = customizationTextures[i];

                texture.GetComponent<UIItemTexture>().itemData = data;
                texture.GetComponent<UIItemTexture>().SetItem(i);
            }
        }
        else
        {
            for (int i = 0; i < data.textures.Count; i++)
            {
                var texture = customizationTextures[i];

                texture.GetComponent<UIItemTexture>().itemData = data;
                texture.GetComponent<UIItemTexture>().SetItem(i);
            }
        }
    }
}