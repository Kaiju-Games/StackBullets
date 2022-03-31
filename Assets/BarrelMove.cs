using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using HCB.Core;

public class BarrelMove : MonoBehaviour
{
    private Tween tween;

    private void OnEnable()
    {
        EventManager.BulletDecrease.AddListener(BarrelAnimation);
    }

    private void OnDisable()
    {
        EventManager.BulletDecrease.RemoveListener(BarrelAnimation);
    }
    [Button]
    private void BarrelAnimation()
    {
        if (tween != null)
            tween.Kill(true);
        tween = transform.DOPunchPosition(Vector3.forward / 2, 1f, 3);
    }
}