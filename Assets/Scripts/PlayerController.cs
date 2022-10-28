using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField,Header("プレイヤーのスピード")]private float _speed = 5;
    Rigidbody2D rb;
    bool _isMove = false;
    /// <summary>スピードのプロパティ</summary>
    public float Speed { get => _speed; set => _speed = value; }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.IsStarted)
        { 
            _isMove = true;
        }
        else
        {
            _isMove = false; 
        }
        if(_isMove)
        {
            CharacterMove();
        }
        else if(!_isMove)
        { 
            rb.velocity = Vector2.zero; 
        }
    }

    void CharacterMove()
    {
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * _speed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.instance.GetItemScore(200);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Bomb"))
        {
            GameManager.instance.GetItemScore(-300);
            Destroy(collision.gameObject);
        }
    }
}
