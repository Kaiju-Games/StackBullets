using HCB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BulletMove bullets = other.GetComponentInParent<BulletMove>();
        
        
        if(bullets != null)
        {
            HapticManager.Haptic(HapticTypes.RigidImpact);
            Debug.Log("Bam");
            GetComponentInChildren<ScoreManager>().RemovePoint();
        }
    }
}
