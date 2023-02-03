using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField,Header("プレイヤーのスピード")]private float _speed = 5;
    [SerializeField]
    ParticleSystem _starParticle = default;
    Rigidbody2D _rb;
    Animator _animator;
    /// <summary>animatorのIdを渡す。</summary>
    private readonly int RunId = Animator.StringToHash("Run");
    private readonly int HitAnimId = Animator.StringToHash("Hit");
    /// <summary>スピードのプロパティ</summary>
    public float Speed { get => _speed; set => _speed = value; }
    private float x;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        //_animator.SetFloat("Speed", 0);
        _rb.velocity = Vector2.zero;
        _animator.SetBool(RunId, false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.IsStarted)
        {
            CharacterMove();
        }
    }

    void CharacterMove()
    {
        x = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(x * _speed, _rb.velocity.y);
        if(x!=0)
        {
            _animator.SetBool(RunId, true);
            Vector2 lscale = gameObject.transform.localScale;
            if ((lscale.x > 0 && x < 0)
                || (lscale.x < 0 && x > 0))
            {
                lscale.x *= -1;
                gameObject.transform.localScale = lscale;
            }
        }
        if(!Input.anyKey)//何も押されていないときはIdle状態に遷移する
        {
            _animator.SetBool(RunId, false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.instance.GetItemScore(200);
            _speed += 1;
            Destroy(collision.gameObject);
            Instantiate(_starParticle, transform);
            Destroy(_starParticle, 0.5f);
        }
        if(collision.gameObject.CompareTag("Bomb"))
        {
            GameManager.instance.GetItemScore(-300);
            _animator.SetBool(HitAnimId, true);
            _rb.velocity = Vector2.zero;
            Invoke(nameof(DamageAnimActive), 0.2f);
            if(_speed>0)
            { _speed -= 1; }
            Destroy(collision.gameObject);
        }
    }
    public void DamageAnimActive()
    {
        _animator.SetBool(HitAnimId, false);
        _rb.velocity = new Vector2(x * _speed, _rb.velocity.y);
    }
}
