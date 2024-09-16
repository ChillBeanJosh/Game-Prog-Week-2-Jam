using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnLocations;
    public float spawnTime;


    private void Start()
    {

        //Invoke Repeating ("Method Name", value of time until it starts, value of how often it repeats).
        InvokeRepeating("SpawnEnemy", 0f, spawnTime);
    }

    public void SetSpawnTime(float newSpawnTime)
    {
        spawnTime = newSpawnTime;

        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", 0f, spawnTime);

    }

    void SpawnEnemy()
    {
        //Creates a Randomizer.
        int randomLocation = Random.Range(0, spawnLocations.Length);
        Transform spawnPoint = spawnLocations[randomLocation];

        //Randomly Spawns the enemy using randomizer.
        GameObject spawnedEnemy = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);

    }
}
