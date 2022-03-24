using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float _speed = 5f;

    Rigidbody _bulletRb;


    private void Start()
    {
        _bulletRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _bulletRb.AddForce(Vector3.forward * _speed, ForceMode.Impulse);
    }
}
