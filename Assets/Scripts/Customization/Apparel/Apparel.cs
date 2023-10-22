using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Apparel : MonoBehaviour
{
    public CustomizationItem data;
    public Renderer renderer;

    public virtual void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
       
    }

    protected virtual void OnEnable()
    {
        EventManager.TextureItemClicked += TextureItemClicked;
    }

    protected virtual void OnDisable()
    {
        EventManager.TextureItemClicked -= TextureItemClicked;
    }

    private void TextureItemClicked(CustomizationItem itemData, int id)
    {
        if (itemData.id != data.id) return;

        if (id == 0)
        {
            foreach (var mat in renderer.materials)
            {
                mat.SetTexture("_BaseMap", null);
            }
        }
        else
        {
            foreach (var mat in renderer.materials)
            {
                mat.SetTexture("_BaseMap", data.textures[id]);
            }
        }
    }
}