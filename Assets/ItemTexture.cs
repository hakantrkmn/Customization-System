using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTexture : MonoBehaviour
{
    public Customization data;
    public Image image;
    public int textureId;

    public void SetItem(int id)
    {
        textureId = id;
        var sp = Sprite.Create(data.textures[textureId], new Rect(0, 0, data.textures[textureId].width, data.textures[textureId].height), Vector2.zero);
        image.sprite = sp;
    }

    public void TextureItemClicked()
    {
        EventManager.TextureItemClicked(data, textureId);
    }
}
