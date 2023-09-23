using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Apparel : MonoBehaviour
{
    public Customization data;
    public Renderer renderer;

    private void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
    }

    private void OnEnable()
    {
        EventManager.TextureItemClicked += TextureItemClicked;
    }

    private void OnDisable()
    {
        EventManager.TextureItemClicked -= TextureItemClicked;
    }

    private void TextureItemClicked(Customization itemData, int id)
    {
        if (itemData.id==data.id)
        {
            renderer.material.SetTexture("_BaseMap",data.textures[id]);
        }
    }
}
