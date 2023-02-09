using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    float interval = 2.0f;
    float time;
    float randomItemSpawn;
    [SerializeField] private GameObject[] itemPrefab = default;
    private bool _isSpawn;
    public bool IsSpawn { get => _isSpawn; set => _isSpawn = value; }
    void Update()
    {
        interval = Random.Range(2.0f, 7.0f);
        randomItemSpawn = Random.Range(0, 101);
        time += Time.deltaTime;
        if (time > interval && GameManager.instance.IsStarted)
        {
            Generate();
        }
    }

    /// <summary>�e�̐���</summary>
    void Generate()
    {
        //80%�̊m���Œʏ�A�C�e������
        if (randomItemSpawn >= 20)
        {
            Instantiate(itemPrefab[0], transform.position, Quaternion.identity);
            time = 0;
        }
        //20%�̊m���Ŕ��e����
        else
        {
            Instantiate(itemPrefab[1], transform.position, Quaternion.identity);
            time = 0;
        }
    }
}
//public class ItemSpaener:MonoBehaviour
//{
//    [SerializeField]
//    float interval = 2.0f;
//    float randomItemSpawn;
//    [SerializeField] private GameObject[] itemPrefab = default;
//    private bool _isSpawn;
//    public bool IsSpawn { get => _isSpawn; set => _isSpawn = value; }
//    [SerializeField]
//    ItemController _itemController = default;
//    private void Start()
//    {
//        if (GameManager.instance.IsStarted)
//        {
//            StartCoroutine(Run());
//        }
//    }
//    private void Update()
//    {
//        randomItemSpawn = Random.Range(0, 101);
//    }
//    private IEnumerator Run()
//    {
//        while (true)
//        {
//            //yield return new WaitForSeconds(interval); // �w�莞�Ԃ̌o�߂�҂�
//            Spawn();
//            //yield return new WaitForSeconds(interval); // �w�莞�Ԃ̌o�߂�҂�
//            //Spawn();
//        }
//    }

//    private void Spawn()
//    {
//        //80 % �̊m���Œʏ�A�C�e������
//        if (randomItemSpawn >= 20)
//        {
//            var item = Instantiate(itemPrefab[0], transform.position, Quaternion.identity);
//            var rb = item.GetComponent<Rigidbody2D>();
//            rb.AddForce(force*_itemController.Power, ForceMode2D.Impulse);
//        }
//        ////20%�̊m���Ŕ��e����
//        else
//        {
//            var item = Instantiate(itemPrefab[1], transform.position, Quaternion.identity);
//            var rb = item.GetComponent<Rigidbody2D>();
//            rb.AddForce(force*_itemController.Power, ForceMode2D.Impulse);
//        }
//    }
//}

