using System;
using UnityEngine;


public static class EventManager
{
    
    

    #region InputSystem
    public static Func<Vector2> GetInput;
    public static Func<Vector2> GetInputDelta;
    public static Action InputStarted;
    public static Action InputEnded;
    public static Func<bool> IsTouching;
    public static Func<bool> IsPointerOverUI;
    #endregion



    public static Action<CustomizationCategories> TabButtonClicked;

    public static Action<CustomizationItem> ItemClicked;
    public static Func<float> GetAnimTime;

    public static Action<CustomizationItem,int> TextureItemClicked;
    public static Action DanceStateChanged;

    public static Func<int> GetDanceIndex;
    public static Func<int,bool> CheckIfItemUsing;

    public static Func<int,int> GetCurrentUsingTextureId;

}