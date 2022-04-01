using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using HCB.Core;
using HCB.SplineMovementSystem;

public class WallObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] wallPieces;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        foreach (var wall in wallPieces)
        {
            wall.AddComponent<Rigidbody>().isKinematic = true;
            wall.AddComponent<MeshCollider>().convex = true;
        }
    }

    [Button]
    public void DestructWall()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;


        foreach (var wall in wallPieces)
        {
            wall.GetComponent<Rigidbody>().isKinematic = false;
            
            wall.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2)) * 200);
        }
    }

    private bool isCollided;

    private void OnTriggerEnter(Collider other)
    {
        SplineCharacter splineCharacter = other.GetComponentInParent<SplineCharacter>();

        if (splineCharacter != null && !isCollided)
        {
            isCollided = true;
            GameManager.Instance.CompeleteStage(false);

        }
        









        //Bullets sc = splineCharacter.GetComponent<StackController>();





        //if (other.gameObject == splineCharacter)
        //{
        //    GameManager.Instance.CompeleteStage(false);
        //    
        //    return;
        //}

        ////sc.CurrentCollectibles[sc.CurrentCollectibles.Count - 1].Uncollect(sc);
        //HapticManager.Haptic(HapticTypes.RigidImpact);

    }
}
