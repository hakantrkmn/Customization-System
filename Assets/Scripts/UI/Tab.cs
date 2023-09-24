using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class Tab : MonoBehaviour
{
    public CustomizationCategories category;
    public TextMeshProUGUI categoryText;
    
    public void SetTab()
    {
        categoryText.text = category.ToString();
        transform.name = category.ToString();
    }

    public void TabButtonClicked()
    {
        EventManager.TabButtonClicked(category);
    }

    
}
