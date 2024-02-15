using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject bomb;
    public Transform enemySpawnPoint;
    public Transform bombSpawnPoint;
    public float SpawnIntervalBomb = 5.0f;
    public float SpawnIntervalEnemy = 8.0f;

    private float NextSpawnTimeBomb;
    private float NextSpawnTimeEnemy;
    void Update()
    {
        if (Time.time >= NextSpawnTimeBomb)
        {
            SpawnBomb();
            NextSpawnTimeBomb = Time.time + SpawnIntervalBomb;
        }
        if (Time.time >= NextSpawnTimeEnemy)
        {

            SpawnEnemy();
            NextSpawnTimeEnemy = Time.time + SpawnIntervalEnemy;
        }
    }

    void SpawnBomb()
    {
        GameObject Bomb = Instantiate(bomb, bombSpawnPoint.position, bombSpawnPoint.rotation);
    }    
    void SpawnEnemy()
    {
        
        GameObject Enemy = Instantiate(enemy, enemySpawnPoint.position, enemySpawnPoint.rotation);
    }
}
