using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawnEnemyDelay;

    [SerializeField]
    private Transform [] spawnPoints;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy",0, spawnEnemyDelay);
    }

    private Transform SelectSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length -1)];
    }

    private void SpawnEnemy()
    {
        Transform spawnPointPosition = SelectSpawnPoint();
        Instantiate(enemyPrefab, spawnPointPosition.position, Quaternion.identity);
    }

}
