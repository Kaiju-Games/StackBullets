using HCB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float _speed = 50f;

    Rigidbody _bulletRb;

    private bool _canShoot = true;

   

    private void Start()
    {
        _bulletRb = GetComponentInChildren<Rigidbody>();
        
  
    }

    private void FixedUpdate()
    {
        Fire();
    }

    void Fire()
    {
        if (!_canShoot) return;
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        /*_bulletRb.AddForce(transform.forward * _speed, ForceMode.Impulse)*/; //transform.translate ile degisecek
    }

}
