using HCB.Core;
using HCB.SplineMovementSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletArea : MonoBehaviour
{
    private SplineCharacter _splineCharacter;
    private bool _isEnteredBulletArea;
    private bool _isExitedBulletArea;

   

    private bool _isCollided;

    [SerializeField] private Transform _scraper;
    [SerializeField] private GameObject _spiralGeneratorPrefab;

    [SerializeField] private Transform _tankStorage;
    GameObject _spiralGenerator;

    SpiralMeshChanger _spiralMeshChanger;
    

    private void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name); // bu degdigi seylerin ismini donecek.

        _splineCharacter = other.GetComponentInParent<SplineCharacter>();


        if (_splineCharacter != null && !_isCollided)
        {
            _isCollided = true;

            Debug.Log("Boom");

            //EventManager.OnBulletTake.Invoke();

            _spiralGenerator = Instantiate(_spiralGeneratorPrefab, _scraper.position, Quaternion.identity);

            _spiralGenerator.transform.SetParent(_scraper);
        }

        _isEnteredBulletArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _splineCharacter = other.GetComponentInParent<SplineCharacter>();
        


        if (_splineCharacter != null && _isCollided)
        {
            _isCollided = false;
            Debug.Log("Exited");

            //for Tank Arm Animation 
            EventManager.OnBulletTakeExit.Invoke();

            _spiralGenerator.transform.SetParent(null);
            _spiralGenerator.GetComponent<MeshGenerator>().StopScraping();

            //Tank sepetinde biriktirmek icin pos
            Vector3 spawnPos = Vector3.zero;

            spawnPos = _tankStorage.transform.position;



            _spiralGenerator.transform.SetParent(_tankStorage);

            //Componenti burada aliyoruz cunku OnTriggerEnter'da olusturuluyor prefab'i
            _spiralMeshChanger = _spiralGenerator.GetComponentInParent<SpiralMeshChanger>();

            _spiralGenerator.transform.DOLocalJump(Vector3.zero, 5, 1, 2f);




            //changing Mesh
            _spiralMeshChanger.MeshChanger();
            


        }

        _isExitedBulletArea = true ;
    }

}
