using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor.Animations;
using UnityEngine;

public class Clothing : Apparel
{
    public override void Start()
    {
        base.Start();
        SetBones();
    }

    [Button]
    public void SetBones()
    {
        var sa = renderer as SkinnedMeshRenderer;

        List<Transform> newList = new List<Transform>();
        foreach (var bone in sa.bones)
        {
            var targetBone = EventManager.GetBoneWithString(bone.name);
            newList.Add(targetBone);
        }

        sa.bones = newList.ToArray();
        
        sa.rootBone = EventManager.GetBonesTransform().rootBone;
    }
}