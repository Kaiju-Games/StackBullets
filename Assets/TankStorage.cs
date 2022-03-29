using HCB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStorage : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.BulletDecrease.AddListener(RemoveBulletVisual);
    }

    private void OnDisable()
    {
        EventManager.BulletDecrease.RemoveListener(RemoveBulletVisual);
    }

    void RemoveBulletVisual()
    {
        if (transform.childCount <= 0)
            return;
        Destroy(transform.GetChild(0).gameObject);
    }
}
