using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIItemTexture : MonoBehaviour
{
    public CustomizationItem itemData;
    public Image image;
    [HideInInspector]public int textureId;
    public GameObject selectedImage;
    public void SetItem(int id)
    {
        textureId = id;
        var sp = Sprite.Create(itemData.textures[textureId], new Rect(0, 0, itemData.textures[textureId].width, itemData.textures[textureId].height), Vector2.zero);
        image.sprite = sp;

        if (EventManager.GetCurrentUsingTextureId(itemData.id)==textureId)
        {
            selectedImage.SetActive(true);
        }
        else
        {
            selectedImage.SetActive(false);
        }
    }

    private void OnEnable()
    {
        EventManager.TextureItemClicked += TextureItemClicked;
    }

    private void OnDisable()
    {
        EventManager.TextureItemClicked -= TextureItemClicked;
    }

    private void TextureItemClicked(CustomizationItem itemData, int textureId)
    {
        if (textureId!=this.textureId)
        {
            selectedImage.SetActive(false);

        }
    }

    public void TextureItemClicked()
    {
        EventManager.TextureItemClicked(itemData, textureId);
        selectedImage.SetActive(true);
    }
}
