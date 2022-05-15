using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int numOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
    public Transform[] spawnPointsBoss;

    private Wave currentWave;
    public int currentWaveNumber;

    public bool canSpawn = true;
    private float nextSpawnTime;

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();

        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("EnemyGround");

        if(totalEnemies.Length == 0 && !canSpawn && currentWaveNumber + 1 != waves.Length)
        {
            SpawnNextWave();
        }

    }

    void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            if(currentWaveNumber != 2)
            {
                GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
                Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
                currentWave.numOfEnemies--;

                nextSpawnTime = Time.time + currentWave.spawnInterval;

                if (currentWave.numOfEnemies == 0)
                    canSpawn = false;
            }
            
            if(currentWaveNumber == 2)
            {
                GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
                Transform randomPoint = spawnPointsBoss[Random.Range(0, spawnPoints.Length)];
                Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
                currentWave.numOfEnemies--;

                nextSpawnTime = Time.time + currentWave.spawnInterval;

                if (currentWave.numOfEnemies == 0)
                    canSpawn = false;
            }
            
        }
    }

}
