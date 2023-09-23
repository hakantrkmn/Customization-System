using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public struct TutorialPanels
{
    public TutorialTypes panelName;
    public GameObject panelGameObject;
}

[Serializable]
public class CharacterItem
{
    public CustomizationCategories category;
    public GameObject itemObject;
    public bool isWearing;
    public int currentTextureIndex;
    public int id;
    public CharacterItem(CustomizationCategories category, GameObject itemObject,int id,bool isWearing,int currentTextureIndex)
    {
        this.category = category;
        this.itemObject = itemObject;
        this.id = id;
        this.isWearing = isWearing;
        this.currentTextureIndex = currentTextureIndex;
    }
    
}


#region Incremental Idle
[Serializable]
public class IncrementalIdleValues
{
    public int currentUpgradeLevel;
    public float totalUpgradeGainValue;
    public bool isMaximized;

    public void ResetValues()
    {
        currentUpgradeLevel = 0;
        totalUpgradeGainValue = 0;
        isMaximized = false;
    }
}

[Serializable]
public class PriceHolderStruct
{
    public string name;
    public List<PriceAnodValue> priceAndValueList = new List<PriceAnodValue>();

    public PriceHolderStruct(string _name, int _length, int _multiplier)
    {
        name = _name;

        for (int i = 0; i < _length; i++)
            priceAndValueList.Add(new PriceAnodValue((i + 1) * _multiplier, (i + 1)));
    }
}

[Serializable]
public class PriceAnodValue
{
    public int requiredMoneyValue;
    public float upgradeAmount;

    public PriceAnodValue(int _requiredMoneyValue, float _upgradeAmount)
    {
        this.requiredMoneyValue = _requiredMoneyValue;
        this.upgradeAmount = _upgradeAmount;
    }
}
#endregion