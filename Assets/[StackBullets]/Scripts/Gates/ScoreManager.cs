using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{



    [SerializeField] private TextMeshPro _gateText;

    [SerializeField] int _score = 2;

   

    void Start()
    {
        _gateText.text = _score.ToString();
    }

    public void RemovePoint()
    {
        GateManager _gateManager = GetComponentInParent<GateManager>();
        WallObstacle wallObstacle = GetComponentInParent<WallObstacle>();
        _score -= 1;
        _gateText.text = _score.ToString();

        if (_score == 0)
        {
            _score = 0;
            Destroy(_gateManager);
            wallObstacle.DestructWall();
            Destroy(_gateText.gameObject);

        }
            
    }

   
}
