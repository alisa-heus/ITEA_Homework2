using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _fallingEnemy;
    [SerializeField] float _spawnDelay;
    private bool _canSpawn;

    private void Start()
    {
        _canSpawn = true;
    }

    void Update()
    {
        if(_canSpawn)
        {
            StartCoroutine("SpawnEnemy");   
        }
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(_fallingEnemy, transform.position, Quaternion.identity);
        _canSpawn = false;
        yield return new WaitForSeconds(_spawnDelay);
        _canSpawn = true;        
    }
}
