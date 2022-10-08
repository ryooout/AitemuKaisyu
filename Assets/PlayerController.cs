using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
    }

    void CharacterMove()
    {
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x, rb.velocity.y)*speed;
    }
}
