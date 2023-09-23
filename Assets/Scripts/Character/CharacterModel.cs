using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

public class CharacterModel : MonoBehaviour
{
    public List<CharacterItem> items;
    public CustomizationData data;
    List<CharacterBodyPart> _bodyParts;
    CharacterAnimationController _animationController;


    private void Start()
    {
        SetCustomizationItems();
    }


    [Button]
    public void SetCustomizationItems()
    {
        _bodyParts = new List<CharacterBodyPart>();
        _animationController = GetComponent<CharacterAnimationController>();
        _bodyParts.Clear();

        foreach (var bodyPart in GetComponentsInChildren<CharacterBodyPart>())
        {
            _bodyParts.Add(bodyPart);
        }

        foreach (var item in items)
        {
#if UNITY_EDITOR
            DestroyImmediate(item.itemObject);
#else
            Destroy(item.itemObject);
#endif
        }

        items.Clear();
        foreach (var itemData in data.customizationList)
        {
            var item = PrefabUtility.InstantiatePrefab(itemData.model, transform) as GameObject;
            item.transform.SetParent(_bodyParts.First(x => x.category == itemData.customizationCategory).transform);
            CharacterItem chItem = new CharacterItem(itemData.customizationCategory, item, itemData.id, false, 0);
            if (itemData.itemType == ItemType.Clothing)
            {
                var sc = item.AddComponent<Clothing>();
                sc.SetAnimation(_animationController.animator);
                sc.data = itemData;
            }
            else
            {
                var sc = item.AddComponent<Accessorie>();
                sc.data = itemData;
            }

            item.SetActive(false);
            items.Add(chItem);
        }
    }

    private void OnEnable()
    {
        EventManager.GetCurrentUsingTextureId += GetCurrentUsingTextureId;
        EventManager.TextureItemClicked += TextureItemClicked;
        EventManager.CheckIfItemUsing += CheckIfItemUsing;
        EventManager.ItemClicked += ItemClicked;
    }

    private int GetCurrentUsingTextureId(int id)
    {
        return items.First(x => x.id == id).currentTextureIndex;
    }

    private void TextureItemClicked(CustomizationItem itemData, int index)
    {
        items.First(x => x.id == itemData.id).currentTextureIndex = index;
    }

    private bool CheckIfItemUsing(int id)
    {
        return items.First(x => x.id == id).isWearing;
    }

    private void OnDisable()
    {
        EventManager.TextureItemClicked -= TextureItemClicked;
        EventManager.ItemClicked -= ItemClicked;
    }

    private void ItemClicked(CustomizationItem itemData)
    {
        foreach (var item in items)
        {
            if (itemData.takeOffCategories.Contains(item.category))
            {
                item.itemObject.SetActive(false);
                item.isWearing = false;
            }
        }

        foreach (var it in items)
        {
            if (it.id == itemData.id)
            {
                it.itemObject.SetActive(true);
                if (it.itemObject.GetComponent<Clothing>())
                {
                    it.itemObject.GetComponent<Clothing>().Dance();
                }

                it.isWearing = true;

                return;
            }
        }
    }
}