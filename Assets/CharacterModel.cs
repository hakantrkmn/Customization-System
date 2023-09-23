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
    public List<CharacterBodyPart> bodyParts;

    public CharacterAnimationController animationController;

    public CustomizationData data;
   
    

    [Button]
    public void SetData()
    {
        bodyParts.Clear();

        foreach (var bodyPart in GetComponentsInChildren<CharacterBodyPart>())
        {
            bodyParts.Add(bodyPart);
        }
        
        foreach (var item in items)
        {
            DestroyImmediate(item.itemObject);
        }
        items.Clear();
        foreach (var itemData in data.customizationList)
        {
            var item = PrefabUtility.InstantiatePrefab(itemData.model, transform) as GameObject;
            item.transform.SetParent(bodyParts.First(x => x.category==itemData.customizationCategory).transform);
            CharacterItem chItem = new CharacterItem(itemData.customizationCategory, item,itemData.id,false,0);
            if (itemData.customizationCategory!=CustomizationCategories.Accessories)
            {
                var sc = item.AddComponent<Clothing>();
                sc.SetAnimation(animationController.animator);
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

    private void TextureItemClicked(Customization itemData, int index)
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

    private  void ItemClicked(Customization itemData)
    {
        switch (itemData.customizationCategory)
        {
            case CustomizationCategories.FullBody:
                foreach (var it in items)
                {
                    if (it.category is CustomizationCategories.TopBody or CustomizationCategories.BottomBody
                        or CustomizationCategories.FullBody)
                    {
                        it.itemObject.SetActive(false);
                        it.isWearing = false;
                    }
                }
                break;
            case CustomizationCategories.TopBody:
                foreach (var it in items)
                {
                    if(it.category == CustomizationCategories.TopBody ||it.category == CustomizationCategories.FullBody)
                    {
                        it.itemObject.SetActive(false);
                        it.isWearing = false;
                    }
                }
                break;
            case CustomizationCategories.BottomBody:
                foreach (var it in items)
                {
                    if( it.category==CustomizationCategories.BottomBody||it.category == CustomizationCategories.FullBody)
                    {
                        it.itemObject.SetActive(false);
                        it.isWearing = false;
                    }
                }
                break;
            case CustomizationCategories.Accessories:
                break;
            case CustomizationCategories.Shoe:
                foreach (var it in items)
                {
                    if(it.category == CustomizationCategories.Shoe )
                    {
                        it.itemObject.SetActive(false);
                        it.isWearing = false;
                    }
                }
                break;
            case CustomizationCategories.Sock:
                foreach (var it in items)
                {
                    if(it.category == CustomizationCategories.Sock)
                    {
                        it.itemObject.SetActive(false);
                        it.isWearing = false;
                    }
                }
                break;
            case CustomizationCategories.OuterBody:
                foreach (var it in items)
                {
                    if(it.category == CustomizationCategories.OuterBody)
                    {
                        it.itemObject.SetActive(false);
                        it.isWearing = false;
                    }
                }
                break;
        }

        foreach (var it in items)
        {
            if (it.id == itemData.id)
            {
                {
                    it.itemObject.SetActive(true);
                    if (it.itemObject.GetComponent<Clothing>())
                    {
                        it.itemObject.GetComponent<Clothing>().Dance();
                    }
                    it.isWearing = true;
                }
                return;
            }
        }

       
    }
}
