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

    public CustomizationData data;
    public List<ItemTexture> customizationTextures;

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

    [Button]
    private void ItemClicked(Customization data)
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
                var cloth = customizationTextures[i];

                cloth.GetComponent<ItemTexture>().data = data;
                cloth.GetComponent<ItemTexture>().SetItem(i);
            }
        }
        else if (data.textures.Count > customizationTextures.Count)
        {
            Debug.Log("büyük");

            for (int i = customizationTextures.Count; i < data.textures.Count; i++)
            {
                var cloth = PrefabUtility.InstantiatePrefab(textureUIPrefab, transform) as GameObject;
                customizationTextures.Add(cloth.GetComponent<ItemTexture>());
            }

            for (int i = 0; i < data.textures.Count; i++)
            {
                var cloth = customizationTextures[i];

                cloth.GetComponent<ItemTexture>().data = data;
                cloth.GetComponent<ItemTexture>().SetItem(i);
            }
        }
        else
        {
            for (int i = 0; i < data.textures.Count; i++)
            {
                var cloth = customizationTextures[i];

                cloth.GetComponent<ItemTexture>().data = data;
                cloth.GetComponent<ItemTexture>().SetItem(i);
            }
        }
    }
}