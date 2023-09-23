using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public Animator animator;

    float _animTime;

    [OnValueChanged("Dance")] public Dances dance;

    private void Update()
    {
        _animTime += Time.deltaTime * .1f;
        animator.SetFloat("AnimTime", _animTime);
    }

    private void OnEnable()
    {
        EventManager.GetDanceIndex += GetDanceIndex;
        EventManager.GetAnimTime += GetAnimTime;
    }

    private int GetDanceIndex()
    {
        return animator.GetInteger("Dance");
    }

    private void OnDisable()
    {
        EventManager.GetDanceIndex -= GetDanceIndex;
        EventManager.GetAnimTime -= GetAnimTime;
    }

    private float GetAnimTime()
    {
        return _animTime;
    }

    private void Dance()
    {
        _animTime = 0;

        switch (dance)
        {
            case Dances.Dance_1:
                animator.SetInteger("Dance", 1);
                break;
            case Dances.Dance_2:
                animator.SetInteger("Dance", 2);

                break;
            case Dances.Idle:
                animator.SetInteger("Dance", 0);

               break;
        }

        if (EventManager.DanceStateChanged!=null)
        {
            EventManager.DanceStateChanged();
        }
    }
}