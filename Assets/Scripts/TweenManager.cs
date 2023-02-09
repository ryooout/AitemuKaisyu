using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
public class TweenManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _timeUpText = default;
    void Start()
    {
        _timeUpText.transform.DOScale(2f, 0.5f);
        _timeUpText.material.DOColor(Color.red, 0.5f);
        _timeUpText.text = "Time Up!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
