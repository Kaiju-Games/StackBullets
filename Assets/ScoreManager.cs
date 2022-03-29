using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;



    [SerializeField] private TextMeshPro _gateText;

    int _score = 5;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _gateText.text = _score.ToString();
    }

    public void RemovePoint()
    {
        GateManager _gateManager = GetComponent<GateManager>();
        _score -= 1;
        _gateText.text = _score.ToString();

        if (_score == 0)
            Destroy(_gateManager.gameObject);
    }

   
}
