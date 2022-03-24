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

    private bool _isCollided;

    [SerializeField] private Transform _scraper;
    [SerializeField] private GameObject _spiralGeneratorPrefab;
    GameObject _spiralGenerator;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name); // bu degdigi seylerin ismini donecek.

        _splineCharacter = other.GetComponentInParent<SplineCharacter>();


        if (_splineCharacter != null && !_isCollided)
        {
            _isCollided = true;

            Debug.Log("Boom");
            EventManager.OnBulletTake.Invoke();
            _spiralGenerator = Instantiate(_spiralGeneratorPrefab, _scraper.position, Quaternion.identity);

            _spiralGenerator.transform.SetParent(_scraper);
        }

        _isEnteredBulletArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _splineCharacter = other.GetComponentInParent<SplineCharacter>();
        
        if(_splineCharacter != null && _isCollided)
        {
            Debug.Log("Exited");
            EventManager.OnBulletTakeExit.Invoke();
            
        }

        _isExitedBulletArea = true ;
    }

}
