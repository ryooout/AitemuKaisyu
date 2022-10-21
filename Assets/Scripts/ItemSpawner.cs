using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    float interval = 2.0f;
    float time;
    [SerializeField]private GameObject itemPrefab = default;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>interval)
        {
            Instantiate(itemPrefab, transform.position , Quaternion.identity);
            time = 0;
        }
    }
}
