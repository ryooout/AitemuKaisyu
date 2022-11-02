using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField, Header("スコア")]
    private int _score;
    [SerializeField, Header("タイマー")]
    private float _timer = 60f;
    [SerializeField, Header("カウントダウンのタイマー")]
    private TextMeshProUGUI _countTimer;
    [SerializeField, Header("スコアのテキスト")]
    private TextMeshProUGUI _scoreText;
    [SerializeField, Header("タイマーのテキスト")]
    private TextMeshProUGUI _timertext;
    [SerializeField, Header("タイムアップのテキスト")]
    private TextMeshProUGUI _timeUpText;
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
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        StartCoroutine(CountDownTimer());
        _isStarted = false;
        _score = 0;
    }
    private void Update()
    {
        if(_isStarted)
        {
            _timertext.gameObject.SetActive(true);
            _scoreText.gameObject.SetActive(true);
            _timer -= Time.deltaTime;
            _timertext.text = $"残り時間:{(int)_timer / 60}:{_timer % 60:F2}";
        }
        if(_timer <=0)
        {
            _timer = 0;
            _timeUpText.transform.DOScale(2f, 0.1f).SetEase(Ease.OutElastic);
            _timeUpText.text = "Time Up!";  
            _isStarted = false;
        }
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
    /// <summary>スコア加算のメソッド</summary>
    public void GetItemScore(int score)
    {
        _score += score;
        _scoreText.text = $"Score:{_score}";
    }
}
