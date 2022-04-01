using HCB.Core;
using HCB.SplineMovementSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace AutoLayout3D
{
    public class BulletArea : MonoBehaviour
    {
        /*private SplineCharacter _splineCharacter;*/ //burada tanimlarsam hafizada bosuna yer tutar
        private bool _isEnteredBulletArea;
        private bool _isExitedBulletArea;

        private float _startTime;
        [SerializeField] private float _bulletPerTime;

        public GameObject dummyPrefab;

        [SerializeField] private GameObject _bulletPrefab;


        private bool _isCollided;

        [SerializeField] private Transform _scraper;
        [SerializeField] private GameObject _spiralGeneratorPrefab;

        
        GameObject _spiralGenerator;

        SpiralMeshChanger _spiralMeshChanger;



        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name); // bu degdigi seylerin ismini donecek.

            SplineCharacterClampController _splineCharacter = other.GetComponent<SplineCharacterClampController>();


            if (_splineCharacter != null && !_isCollided)
            {
                _isCollided = true;

                Debug.Log("Boom");

                //EventManager.OnBulletTake.Invoke();

                _spiralGenerator = Instantiate(_spiralGeneratorPrefab, _scraper.position, Quaternion.identity);

                _spiralGenerator.transform.SetParent(_scraper);

                _isEnteredBulletArea = true;

                _startTime = Time.time;
            }


        }

        private void OnTriggerExit(Collider other)
        {
            SplineCharacterClampController _splineCharacter = other.GetComponent<SplineCharacterClampController>();
            LayoutElement3D layoutElement3D = GetComponentInParent<LayoutElement3D>();
    

        if (_splineCharacter != null && _isCollided)
            {
                //bu bize ne kadar on trigger'da kaldigimizi donecek.
                float timeSpent = Time.time - _startTime;

                int bulletToCreate = Mathf.RoundToInt(timeSpent / _bulletPerTime);
                Debug.Log(bulletToCreate + "bullets");

                _isCollided = false;
                Debug.Log("Exited");

                //for Tank Arm Animation 
                EventManager.OnBulletTakeExit.Invoke();

                
                _spiralGenerator.GetComponent<MeshGenerator>().StopScraping();

                //Tank sepetinde biriktirmek icin pos
                Vector3 spawnPos = Vector3.zero;

                //Componenti burada aliyoruz cunku OnTriggerEnter'da olusturuluyor prefab'i
                _spiralMeshChanger = _spiralGenerator.GetComponentInParent<SpiralMeshChanger>();


                //dummy 3DLayout obje olusturup onun icersine DoJump yapacagiz
                GameObject dummy = Instantiate(dummyPrefab, _splineCharacter.TankStorage);

                _splineCharacter.TankStorage.GetComponent<GridLayoutGroup3D>().UpdateLayout();

                _spiralGenerator.transform.SetParent(dummy.transform);

                _spiralGenerator.transform.DOLocalJump(Vector3.zero, 3, 1, 2f).SetEase(Ease.OutExpo).OnComplete(()=> EventManager.BulletIncrease.Invoke());
                _spiralGenerator.transform.DOLocalRotate(Vector3.zero, 2f);


                //changing Mesh
                _spiralMeshChanger.MeshChanger();

                //Ekstra bullet
                for (int i = 0; i < bulletToCreate; i++)
                {
                    GameObject bullet = Instantiate(_bulletPrefab, _scraper.position, Quaternion.identity);

                    //bullet.GetComponent<MeshGenerator>().enabled = false;

                    GameObject bulletdummy = Instantiate(dummyPrefab, _splineCharacter.TankStorage);
                    _splineCharacter.TankStorage.GetComponent<GridLayoutGroup3D>().UpdateLayout();
                    bullet.transform.SetParent(bulletdummy.transform);

                    bullet.transform.DOLocalJump(Vector3.zero, 3, 1, 2f).SetEase(Ease.OutExpo).OnComplete(() => EventManager.BulletIncrease.Invoke());
                    bullet.transform.DOLocalRotate(Vector3.zero, 2f);


                    //changing Mesh
                    //bullet.GetComponent<SpiralMeshChanger>().MeshChanger();


                }



                _isEnteredBulletArea = false;



            }


        }

     

    }
}

