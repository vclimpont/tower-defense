using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float firstSpawnTime;
    public float spawnRate;
    public int nbWaves;
    public float timeBtwWaves;
    public List<GameObject> enemiesToSpawn;
    public GameObject smallDestinations;
    public GameObject mediumDestinations;
    public GameObject bigDestinations;

    private int i;
    private int j;
    private float crtTimeAfterWave;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        j = 0;
        crtTimeAfterWave = 0;
        InvokeRepeating("SpawnNextWave", 0, 0.1f);
        InvokeRepeating("SpawnEnemy", firstSpawnTime, spawnRate);
    }

    void SpawnNextWave()
    {
        if(i >= enemiesToSpawn.Count && j < nbWaves)
        {
            crtTimeAfterWave += 0.1f;

            if(crtTimeAfterWave >= timeBtwWaves)
            {
                i = 0;
                crtTimeAfterWave = 0;
                j++;
            }
        }
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
