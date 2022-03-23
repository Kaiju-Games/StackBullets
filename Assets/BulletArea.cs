using HCB.Core;
using HCB.SplineMovementSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletArea : MonoBehaviour
{
    private SplineCharacter _splineCharacter;
    private bool _isEnteredBulletArea;
    private bool _isExitedBulletArea;

    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name); // bu degdigi seylerin ismini donecek.

        _splineCharacter = other.GetComponentInParent<SplineCharacter>();

        if (_splineCharacter != null)
        {
            Debug.Log("Boom");
            EventManager.OnBulletTake.Invoke();
        }

        _isEnteredBulletArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _splineCharacter = other.GetComponentInParent<SplineCharacter>();
        
        if(_splineCharacter != null)
        {
            Debug.Log("Exited");
            EventManager.OnBulletTakeExit.Invoke();
            
        }

        _isExitedBulletArea = true ;
    }

}
