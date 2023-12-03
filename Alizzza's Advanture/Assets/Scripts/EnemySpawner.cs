using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnDelay;
    bool canSpawn;

    private void Start()
    {
        canSpawn = true;
    }

    void Update()
    {
        if(canSpawn)
        {
            StartCoroutine("SpawnEnemy");
            
        }
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
        canSpawn = false;
        yield return new WaitForSeconds(spawnDelay);
        canSpawn = true;
            
    }
}
