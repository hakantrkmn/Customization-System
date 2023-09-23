using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
public class CustomizationData : ScriptableObject
{
    public List<CustomizationItem> customizationList;
    public Texture2D noneTexture;
    
    

    private void OnValidate()
    {
        for (int i = 0; i < customizationList.Count; i++)
        {
            customizationList[i].id = i;
            if (customizationList[i].textures.Count==0)
            {
                customizationList[i].textures.Add(noneTexture);
            }
            else 
            {
                if (customizationList[i].textures[0]!=noneTexture)
                    customizationList[i].textures.Insert(0,noneTexture);
            }
        }
    }
}
