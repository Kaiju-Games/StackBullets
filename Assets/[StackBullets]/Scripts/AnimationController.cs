using HCB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animator _splineCharacterAnim;
    private bool _isEntered;

    private void Awake()
    {
        _splineCharacterAnim = GetComponentInChildren<Animator>();
    }
    private void OnEnable()
    {
        //EventManager.OnBulletTake.AddListener(() => _isEntered = true);
        //EventManager.OnBulletTakeExit.AddListener(() => _isEntered = false);

        EventManager.OnBulletTakeExit.AddListener(TankArmAnim);
    }

    private void OnDisable()
    {
        //EventManager.OnBulletTake.RemoveListener(() => _isEntered = true);
        //EventManager.OnBulletTakeExit.RemoveListener(() => _isEntered = false);

        EventManager.OnBulletTakeExit.RemoveListener(TankArmAnim);
    }

    private void Update()
    {
        //CarveBullet();
        //CarveBulletExit();
    }

    //void CarveBullet()
    //{

    //    if(_isEntered)
    //    _splineCharacterAnim.SetBool("CarveBullet",true);
        
    //}

    //void CarveBulletExit()
    //{
    //    if (!_isEntered)
    //        _splineCharacterAnim.SetBool("CarveBullet", false);
    //}

    void TankArmAnim()
    {
        _splineCharacterAnim.SetTrigger("TankArmAnim");
    }



}
