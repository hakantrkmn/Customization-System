using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTexture : MonoBehaviour
{
    public Customization data;
    public Image image;
    public int textureId;
    public GameObject choosenTexture;
    public void SetItem(int id)
    {
        textureId = id;
        var sp = Sprite.Create(data.textures[textureId], new Rect(0, 0, data.textures[textureId].width, data.textures[textureId].height), Vector2.zero);
        image.sprite = sp;

        if (EventManager.GetCurrentUsingTextureId(data.id)==textureId)
        {
            choosenTexture.SetActive(true);
        }
        else
        {
            choosenTexture.SetActive(false);
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

    private void TextureItemClicked(Customization itemData, int index)
    {
        if (index!=textureId)
        {
            choosenTexture.SetActive(false);

        }
    }

    public void TextureItemClicked()
    {
        EventManager.TextureItemClicked(data, textureId);
        choosenTexture.SetActive(true);
    }
}
