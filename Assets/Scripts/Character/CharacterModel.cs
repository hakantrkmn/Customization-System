using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CharacterModel : MonoBehaviour
{

    public List<CharacterItem> items;
    public CustomizationData data;
    List<CharacterBodyPart> _bodyParts;
    CharacterAnimationController _animationController;



    void Start()
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
            if (itemData.itemType == ItemType.Accessories)
            {

                itemData.model.LoadAssetAsync().Completed += OnAdressableLoaded;
            }

        }
    }


    void OnAdressableLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            var item = PrefabUtility.InstantiatePrefab(handle.Result, transform) as GameObject;
            var itemData = data.customizationList.First(x => x.model.Asset == handle.Result);
            item.transform.SetParent(_bodyParts.First(x => x.category.Contains(itemData.customizationCategory)).transform);
            CharacterItem chItem = new CharacterItem(itemData.customizationCategory, item, itemData.id, false, 0);
            var sc = item.AddComponent<Accessorie>();
            sc.data = itemData;

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
        foreach (var it in items)
        {
            if (it.id == id)
            {
                return it.currentTextureIndex;

            }
        }

        return 0;
    }

    private void TextureItemClicked(CustomizationItem itemData, int index)
    {
        items.First(x => x.id == itemData.id).currentTextureIndex = index;
    }

    private bool CheckIfItemUsing(int id)
    {
        foreach (var it in items)
        {
            if (it.id == id)
            {
                return it.isWearing;

            }
        }

        return false;
    }

    private void OnDisable()
    {
        EventManager.TextureItemClicked -= TextureItemClicked;
        EventManager.ItemClicked -= ItemClicked;
    }

    private async void ItemClicked(CustomizationItem itemData)
    {
        foreach (var item in items)
        {
            if (itemData.takeOffCategories.Contains(item.category))
            {
                item.itemObject.SetActive(false);
                item.isWearing = false;
            }
        }

        if (itemData.itemType == ItemType.Clothing)
        {
            foreach (var it in items)
            {
                if (it.id == itemData.id)
                {
                    it.itemObject.SetActive(true);

                    it.isWearing = true;

                    return;
                }
            }

            AsyncOperationHandle<GameObject> handle = itemData.model.LoadAssetAsync<GameObject>();

            // Bekleyin
            await handle.Task;

            // Instantiate edin
            GameObject item = Instantiate(handle.Result, transform.position, transform.rotation);

            // AssetReference'ı serbest bırakın
            item.transform.SetParent(_bodyParts.First(x => x.category.Contains(itemData.customizationCategory)).transform);
            CharacterItem chItem = new CharacterItem(itemData.customizationCategory, item, itemData.id, false, 0);
            var sc = item.AddComponent<Clothing>();
            sc.data = itemData;

            item.SetActive(false);
            items.Add(chItem);
            chItem.itemObject.SetActive(true);

            chItem.isWearing = true;
            Addressables.Release(handle);

            return;

        }
        else
        {
            foreach (var it in items)
            {
                if (it.id == itemData.id)
                {
                    it.itemObject.SetActive(true);

                    it.isWearing = true;

                    return;
                }
            }
        }


    }
}