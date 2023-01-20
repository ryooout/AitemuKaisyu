using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeOutAnimation : MonoBehaviour
{
    [SerializeField]
    Image _fadeOutImage = default;
    [SerializeField]
    GameManager _gameManager = default;
    private void Awake()
    {
    }
    void Start()
    {
        _fadeOutImage.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>–¾‚é‚­‚È‚é</summary>
    public void EndFadeOutAnimation()
    {
        _fadeOutImage.gameObject.SetActive(false);
    }
}
