using HCB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanController : MonoBehaviour
{
    public Collider MainCollider;
    public Collider[] AllColliders;
    public Rigidbody[] AllRigidbodies;

  

    private void Awake()
    {
       
        DoRagdoll(false);
    }

    public void DoRagdoll(bool isRagdoll)
    {
        foreach (var Rb in AllRigidbodies)
        {
            Rb.isKinematic = !isRagdoll;
        }


        foreach (var col in AllColliders)
            col.enabled = isRagdoll;
        MainCollider.enabled = !isRagdoll;
        GetComponent<Rigidbody>().useGravity = !isRagdoll;
        GetComponent<Animator>().enabled = !isRagdoll;
        
    }

    public void DoRagdollForce(bool isRagdoll, Vector3 direction, float power)
    {
        foreach (var Rb in AllRigidbodies)
        {
            Rb.isKinematic = !isRagdoll;
            Rb.AddForce(direction * power);
        }


        foreach (var col in AllColliders)
            col.enabled = isRagdoll;
        MainCollider.enabled = !isRagdoll;
        GetComponent<Rigidbody>().useGravity = !isRagdoll;
        GetComponent<Animator>().enabled = !isRagdoll;
    }

}
