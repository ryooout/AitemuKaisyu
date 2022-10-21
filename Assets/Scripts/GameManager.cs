using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField, Header("スコア")]
    private int _score;
    [SerializeField, Header("タイマー")]
    private float _timer = 60f;
    [SerializeField, Header("カウントダウンのタイマー")]
    private TextMeshProUGUI _countTimer;
    [SerializeField, Header("スコアのテキスト")]
    private TextMeshProUGUI _scoreText;
    [Header("ゲーム始まっているか")]
    private bool _isStarted;
    /// <summary>スコアのプロパティ</summary>
    public int Score { get => _score; set => _score = value; }
    /// <summary>タイマーのプロパティ</summary>
    public float Timer { get => _timer; set => _timer = value; }
    /// <summary>スタートしているかしていないかのプロパティ</summary>
    public bool IsStarted { get => _isStarted; set => _isStarted = value; }

    private void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        StartCoroutine(CountDownTimer());
        _isStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>カウントダウンのタイマー</summary>
    private IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(1.0f);
        for(int i = 3;i>=0;i--)
        {
            if(i>0)
            {
                yield return new WaitForSeconds(1.0f);
                _countTimer.text = i.ToString();
            }
            else if(i==0)
            {
                yield return new WaitForSeconds(1.0f);
                _countTimer.text = "Start!!";
                yield return new WaitForSeconds(1.0f);
                _isStarted = true;
                _countTimer.gameObject.SetActive(false);
            }
        }
        yield return null;
    }
}
