using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    float interval = 2.0f;
    float time;
    [SerializeField]private GameObject itemPrefab = default;
    private bool _isSpawn;
    public bool IsSpawn { get => _isSpawn; set => _isSpawn = value; }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        interval = Random.Range(2.0f, 7.0f);
        time += Time.deltaTime;
        if(time>interval)
        {
            if (GameManager.instance.IsStarted)
            {
                _isSpawn = true;
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
                time = 0;
            }
            else if(!GameManager.instance.IsStarted)
            {
                _isSpawn = false;
            }
        }
    }    
}
