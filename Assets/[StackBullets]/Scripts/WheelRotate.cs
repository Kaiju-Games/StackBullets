using HCB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    private bool _isRotate;


    private void OnEnable()
    {
        if (Managers.Instance == null) return;

        LevelManager.Instance.OnLevelStart.AddListener(() => _isRotate = true);
        GameManager.Instance.OnStageEnd.AddListener(() => _isRotate = false);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null) return;

        LevelManager.Instance.OnLevelStart.RemoveListener(() => _isRotate = true);
        GameManager.Instance.OnStageEnd.RemoveListener(() => _isRotate = false);
    }



    Transform tr;
    //Speed of rotation;
    public float rotationSpeed = 20f;
    //Axis used for rotation;
    public Vector3 rotationAxis = new Vector3(0f, 1f, 0f);

    //Start;
    void Start()
    {
        //Get transform component reference;
        tr = transform;
    }


    private void Update()
    {
        Rotate();
    }


    void Rotate()
    {
        if (_isRotate)
            tr.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }

}
