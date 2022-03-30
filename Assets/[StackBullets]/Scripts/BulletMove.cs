using HCB.Core;
using HCB.PoolingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletMove : MonoBehaviour
{
    private float _speed = 50f;

    Rigidbody _bulletRb;

    private bool _canShoot = true;

    public Transform visual;
   

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

    private void OnTriggerEnter(Collider other)
    {
        StickmanController stickmanController = other.GetComponent<StickmanController>();

        if (stickmanController != null)
        {
            stickmanController.DoRagdollForce(true, Vector3.forward + Vector3.up / 2, 600);
            gameObject.SetActive(false);
        }
    }
}
