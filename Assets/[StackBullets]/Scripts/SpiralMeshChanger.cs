using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMeshChanger : MonoBehaviour
{
    [SerializeField] MeshRenderer _spiralMeshRenderer;
    [SerializeField] MeshRenderer _bulletMeshRenderer;


    private void Start()
    {
        _bulletMeshRenderer.enabled = false;
    }



    public void MeshChanger()
    {

        _spiralMeshRenderer.enabled = false;
        _bulletMeshRenderer.enabled = true;


    }

}
