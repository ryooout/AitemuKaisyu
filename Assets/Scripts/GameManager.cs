using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField, Header("�X�R�A")]
    private int _score;
    [SerializeField, Header("�^�C�}�[")]
    private float _timer = 60f;
    [SerializeField, Header("�J�E���g�_�E���̃^�C�}�[")]
    private TextMeshProUGUI _countTimer;
    [SerializeField, Header("�X�R�A�̃e�L�X�g")]
    private TextMeshProUGUI _scoreText;
    [SerializeField, Header("�^�C�}�[�̃e�L�X�g")]
    private TextMeshProUGUI _timertext;
    [Header("�Q�[���n�܂��Ă��邩")]
    private bool _isStarted;
    /// <summary>�X�R�A�̃v���p�e�B</summary>
    public int Score { get => _score; set => _score = value; }
    /// <summary>�^�C�}�[�̃v���p�e�B</summary>
    public float Timer { get => _timer; set => _timer = value; }
    /// <summary>�X�^�[�g���Ă��邩���Ă��Ȃ����̃v���p�e�B</summary>
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
        _score = 0;
    }
    private void Update()
    {
        if(_isStarted)
        {
            _timertext.gameObject.SetActive(true);
            _scoreText.gameObject.SetActive(true);
            _timer -= Time.deltaTime;
            _timertext.text = $"�c�莞��:{(int)_timer / 60}:{_timer % 60:F2}";
        }
        if(_timer <=0)
        {
            _timer = 0;
            _isStarted = false;
        }
    }
    /// <summary>�J�E���g�_�E���̃^�C�}�[</summary>
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
    /// <summary>�X�R�A���Z�̃��\�b�h</summary>
    public void GetItemScore(int score)
    {
        _score += score;
        _scoreText.text = $"Score:{_score}";
    }
}
