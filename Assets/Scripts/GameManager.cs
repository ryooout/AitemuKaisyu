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
    }

    // Update is called once per frame
    void Update()
    {
        
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
}