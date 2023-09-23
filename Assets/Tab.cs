using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tab : MonoBehaviour
{
    public CustomizationCategories category;
    public TextMeshProUGUI categoryText;
    
    public void SetTab()
    {
        categoryText.text = category.ToString();
    }

    public void TabButtonClicked()
    {
        EventManager.TabButtonClicked(category);
    }
}
