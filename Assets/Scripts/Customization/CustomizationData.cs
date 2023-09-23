using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
public class CustomizationData : ScriptableObject
{
    public List<Customization> customizationList;


    private void OnValidate()
    {
        for (int i = 0; i < customizationList.Count; i++)
        {
            customizationList[i].id = i;
        }
    }
}
