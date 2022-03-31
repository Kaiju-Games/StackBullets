using HCB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStorage : MonoBehaviour
{

    [SerializeField] private GameObject _emptyLayoutobject;
    private void OnEnable()
    {
        EventManager.BulletDecrease.AddListener(RemoveBulletVisual);
    }

    private void OnDisable()
    {
        EventManager.BulletDecrease.RemoveListener(RemoveBulletVisual);
    }



    private void Update()
    {
        
    }

    void EmptyGameObject()
    {
        
    }


    void RemoveBulletVisual()
    {
        if (transform.childCount <= 0)
            return;
        Destroy(transform.GetChild(0).gameObject);
    }
}
