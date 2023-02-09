using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleManager : MonoBehaviour
{
    [SerializeField] FadeManager _fadeManager = default;
    void Start()
    {
        _fadeManager.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoMainScene(string name)
    {
        _fadeManager.FadeOut(() => SceneManager.LoadScene(name));
    }
}
