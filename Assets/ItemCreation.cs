using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemCreation : MonoBehaviour
{
    [MenuItem("Assets/CreateItem")]
    public static void Init()
    {
        var file = Selection.activeObject as GameObject;
       var sc = (CustomizationData)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Customization/Customization Data.asset",typeof(CustomizationData));
       var item = new CustomizationItem();
       item.model = file;
       item.name = file.name;
       sc.customizationList.Add(item);
    }
}
