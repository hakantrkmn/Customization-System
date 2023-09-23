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

    public static Action<Customization> ItemClicked;
    public static Func<float> GetAnimTime;

    public static Action<Customization,int> TextureItemClicked;



}