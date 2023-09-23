using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Clothing : Apparel
{
    public Animator animator;
    public void SetAnimation(Animator parentAnimator)
    {
        animator = gameObject.AddComponent<Animator>();
        animator.runtimeAnimatorController = parentAnimator.runtimeAnimatorController;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.DanceStateChanged += Dance;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        EventManager.DanceStateChanged -= Dance;
    }


    private void Update()
    {
        animator.SetFloat("AnimTime",EventManager.GetAnimTime());
    }
    
    public void Dance()
    {
        animator.SetInteger("Dance",EventManager.GetDanceIndex());
    }
}