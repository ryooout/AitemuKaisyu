using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] float x,y;
    [SerializeField] float _power;
    Rigidbody2D rb;
    private GameObject player;
    [SerializeField] float min, max;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    private void Start()
    {

        y = Random.Range(min,max);
        rb.AddForce(new Vector2(x, y) * _power,ForceMode2D.Impulse);
        Destroy(gameObject, 3.5f);
        Debug.Log(y);
    }
    private void Update()
    {
        
    }
}
