using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField,Header("アイテムを飛ばす方向")] float x,y;
    [SerializeField,Header("アイテムを飛ばす力")] float _power;
    Rigidbody2D rb;
    [SerializeField] float min, max;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    private void Start()
    {

        y = Random.Range(min,max);
        rb.AddForce(new Vector2(x, y) * _power,ForceMode2D.Impulse);
        Debug.Log(y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {           
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
