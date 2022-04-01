using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BulletMove bullets = other.GetComponentInParent<BulletMove>();
        WallObstacle wallObstacle = GetComponent<WallObstacle>();
        
        if(bullets != null)
        {
            Debug.Log("Bam");
            GetComponentInChildren<ScoreManager>().RemovePoint();
        }
    }
}
