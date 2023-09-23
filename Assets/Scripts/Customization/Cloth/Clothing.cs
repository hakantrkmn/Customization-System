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

    private void Update()
    {
        animator.SetFloat("AnimTime",EventManager.GetAnimTime());
    }
}