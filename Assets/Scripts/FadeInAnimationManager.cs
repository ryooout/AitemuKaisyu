using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class FadeInAnimationManager : MonoBehaviour
{
    [SerializeField]
    Button _startbutton = default;
    [SerializeField]
    string _sceneName = default;
    void Start()
    {
        _startbutton.onClick.AddListener(() => GetComponent<Image>().enabled = true) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>–¾‚é‚­‚È‚é</summary>
    public void EndFadeInAnimation()
    {
        SceneManager.LoadScene(_sceneName);
    }

}
