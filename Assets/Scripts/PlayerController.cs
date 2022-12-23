using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField,Header("プレイヤーのスピード")]private float _speed = 5;
    Rigidbody2D _rb;
    Animator _animator;
    /// <summary>animatorのIdを渡す。</summary>
    private static readonly int RunId = Animator.StringToHash("Run");

    /// <summary>スピードのプロパティ</summary>
    public float Speed { get => _speed; set => _speed = value; }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        //_animator.SetFloat("Speed", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.IsStarted)
        {
            CharacterMove();
        }
        else
        { 
            _rb.velocity = Vector2.zero;
            _animator.SetBool(RunId, false);
        }
    }

    void CharacterMove()
    {
        float x = Input.GetAxis("Horizontal");
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
            if(transform.position.x<=-13.8f)
            {
                transform.position = new Vector2(13.8f, transform.position.y);
            }
            else if(transform.position.x>=13.8f)
            {
                transform.position = new Vector2(-13.8f, transform.position.y);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.instance.GetItemScore(200);
            _speed += 1;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Bomb"))
        {
            GameManager.instance.GetItemScore(-300);
            if(_speed>0)
            { _speed -= 1; }
            
            Destroy(collision.gameObject);
        }
    }
}
