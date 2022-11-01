using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField,Header("アイテムを飛ばす方向")] float x,y;
    private float _power;
    Rigidbody2D rb;
    [SerializeField,Header("y軸にアイテム飛ばす長さの最小,最大")] float min, max;
    [SerializeField, Header("アイテムや爆弾を飛ばす最小,最大")] float power_min, power_max;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    private void Start()
    {

        y = Random.Range(min,max);
        _power = Random.Range(power_min, power_max);
        rb.AddForce(new Vector2(x, y) * _power,ForceMode2D.Impulse);
        Debug.Log(y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
