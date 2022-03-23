using HCB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    private void OnEnable()
    {
        if (Managers.Instance == null) return;

        LevelManager.Instance.OnLevelStart.AddListener(Rotate);
        LevelManager.Instance.OnLevelFinish.AddListener(Rotate);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null) return;

        LevelManager.Instance.OnLevelStart.RemoveListener(Rotate);
        LevelManager.Instance.OnLevelFinish.RemoveListener(Rotate);
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

    //Update;
    void Update()
    {
        //Rotate object;
        Rotate();
       
    }


    void Rotate()
    {
        tr.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }

}
