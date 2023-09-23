using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[Serializable]
public class Customization 
{
    [HideInInspector]public int id;
    public string name;
    public CustomizationCategories customizationCategory;
    public GameObject model;
    public Sprite sprite;
    [PreviewField]
    public List<Texture2D> textures;

}
