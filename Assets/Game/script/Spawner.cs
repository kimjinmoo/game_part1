using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 스폰 포인트
    public Transform[] spawnPoint;

    // 타이머
    float timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1f)
        {
            timer = 0f;
            // 스폰
            Spawn();
            
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
