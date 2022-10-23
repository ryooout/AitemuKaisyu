using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    float interval = 2.0f;
    float time;
    float randomItemSpawn;
    [SerializeField]private GameObject[]itemPrefab = default;
    private bool _isSpawn;
    public bool IsSpawn { get => _isSpawn; set => _isSpawn = value; }
    void Update()
    {
        interval = Random.Range(2.0f, 7.0f);
        randomItemSpawn = Random.Range(0, 101);
        time += Time.deltaTime;
        if (time > interval)
        {
            if (GameManager.instance.IsStarted)
            {
                _isSpawn = true;
            }
            else if (!GameManager.instance.IsStarted)
            {
                _isSpawn = false;
            }
            if (_isSpawn)
            {
                Generate();
            }
        }
    }
    /// <summary>弾の生成</summary>
    void Generate()
    {         //80%の確率で通常アイテム発射
            if (randomItemSpawn >= 20)
            {
                Instantiate(itemPrefab[0], transform.position, Quaternion.identity);
                time = 0;
            }
            //20%の確率で爆弾発射
            else
            {
                Instantiate(itemPrefab[1], transform.position, Quaternion.identity);
                time = 0;
            }
    }
}
