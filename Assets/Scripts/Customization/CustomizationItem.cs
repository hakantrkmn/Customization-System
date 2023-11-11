using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;

[Serializable]
public class CustomizationItem 
{
    [HideInInspector]public int id;
    public string name;
    public CustomizationCategories customizationCategory;
    public ItemType itemType;
    public AssetReferenceGameObject model;
    public Sprite uiSprite;
    [PreviewField]
    public List<Texture2D> textures;
    public List<CustomizationCategories> takeOffCategories;

}
