using HCB.Core;
using HCB.SplineMovementSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletArea : MonoBehaviour
{
    SplineCharacter _splineCharacter;

  

    private void OnTriggerEnter(Collider other)
    {
        _splineCharacter = other.GetComponentInParent<SplineCharacter>();

        if (_splineCharacter != null)
        {
            Debug.Log("Bam");
            EventManager.OnBulletTake.Invoke();
           

        }
    }

}
