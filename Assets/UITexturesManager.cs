using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class UITexturesManager : MonoBehaviour
{
    public GameObject textureUIPrefab;

    public CustomizationData data;
    public List<ItemTexture> customizationTextures;
    private void OnEnable()
    {
        EventManager.ItemClicked += ItemClicked;
    }

    private void OnDisable()
    {
        EventManager.ItemClicked -= ItemClicked;
    }

    [Button]
    private void ItemClicked(Customization data)
    {

        foreach (var item in customizationTextures)
        {
            DestroyImmediate(item.gameObject);
        }
        
        customizationTextures.Clear();
        

        for (int i = 0; i < data.textures.Count; i++)
        {
            var cloth = Instantiate(textureUIPrefab, transform);
            cloth.GetComponent<ItemTexture>().data = data;
            customizationTextures.Add(cloth.GetComponent<ItemTexture>());
            cloth.GetComponent<ItemTexture>().SetItem(i);
        }
        
    }
}
