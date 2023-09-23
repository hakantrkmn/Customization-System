using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public Animator animator;

    public float animTime;


    // Update is called once per frame
    void Update()
    {
            animTime += Time.deltaTime * .1f;
            animator.SetFloat("AnimTime", animTime);
    }

    private void OnEnable()
    {
        EventManager.GetAnimTime += GetAnimTime;
    }

    private void OnDisable()
    {
        EventManager.GetAnimTime -= GetAnimTime;
    }

    private float GetAnimTime()
    {
        return animTime;
    }
    [Button]
    public void Dance_1()
    {
        animTime = 0;
        animator.SetBool("Dance_1",true);
        animator.SetBool("Dance_2",false);

    }
    [Button]
    public void Dance_2()
    {
        animTime = 0;
        animator.SetBool("Dance_1",false);
        animator.SetBool("Dance_2",true);

    }
    
}