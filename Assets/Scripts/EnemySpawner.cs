using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float firstSpawnTime;
    public float spawnRate;
    public List<GameObject> enemiesToSpawn;
    public GameObject smallDestinations;
    public GameObject mediumDestinations;
    public GameObject bigDestinations;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        InvokeRepeating("SpawnEnemy", firstSpawnTime, spawnRate);
    }

    void SpawnEnemy()
    {
        if (i < enemiesToSpawn.Count)
        {
            GameObject enemyGO = Instantiate(enemiesToSpawn[i], transform.position, Quaternion.identity);
            GameObject destinations = null;

            switch(enemyGO.tag)
            {
                case "Small":
                    destinations = smallDestinations;
                    break;
                case "Medium":
                    destinations = mediumDestinations;
                    break;
                case "Big":
                    destinations = bigDestinations;
                    break;
            }
            enemyGO.GetComponent<Enemy>().Initialize(destinations);

            i++;
        }
    }
}
