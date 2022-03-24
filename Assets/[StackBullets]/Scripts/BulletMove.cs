using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float _speed = 50f;

    Rigidbody _bulletRb;


    private void Start()
    {
        _bulletRb = GetComponent<Rigidbody>();
        _bulletRb.AddForce(Vector3.forward * _speed, ForceMode.Impulse);
    }

    private void Update()
    {
        
    }
}
