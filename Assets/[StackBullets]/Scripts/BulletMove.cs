using HCB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float _speed = 50f;

    Rigidbody _bulletRb;

    private bool _canShoot;

   

    private void Start()
    {
        _bulletRb = GetComponent<Rigidbody>();
        Fire();
  
    }

    void Fire()
    {
        _bulletRb.AddForce(transform.forward * _speed, ForceMode.Impulse); //transform.translate ile degisecek
    }

}
