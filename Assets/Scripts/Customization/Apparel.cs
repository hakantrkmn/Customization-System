using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Apparel : MonoBehaviour
{
    public Customization data;
    public Renderer renderer;

     void Start()
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

    private void TextureItemClicked(Customization itemData, int id)
    {
        if (itemData.id==data.id)
        {
            if (id==0)
            {
                renderer.material.SetTexture("_BaseMap",null);

            }
            else
            {
                renderer.material.SetTexture("_BaseMap",data.textures[id]);

            }
        }
    }
}
