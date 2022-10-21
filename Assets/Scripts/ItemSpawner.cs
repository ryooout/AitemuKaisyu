using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    float interval = 2.0f;
    float time;
    [SerializeField]private GameObject itemPrefab = default;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>interval)
        {
            if (GameManager.instance.IsStarted)
            {
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
                time = 0;
            }
        }
    }
    
}
