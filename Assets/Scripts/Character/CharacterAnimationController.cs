using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public Animator animator;

    public SkinnedMeshRenderer renderer;

    [OnValueChanged("Dance")] public Dances dance;
    

    private void OnEnable()
    {
        EventManager.GetBonesTransform += GetBonesTransform;
        EventManager.GetBoneWithString += GetBoneWithString;
    }

    private Transform GetBoneWithString(string boneName)
    {
        foreach (var tr in GetComponentsInChildren<Transform>())
        {
            if (tr.name==boneName)
            {
                return tr;
            }
        }

        return null;
    }

    private SkinnedMeshRenderer GetBonesTransform()
    {
        return renderer;
    }


    private void OnDisable()
    {
        EventManager.GetBoneWithString -= GetBoneWithString;
    }



    private void Dance()
    {
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
        
    }
}