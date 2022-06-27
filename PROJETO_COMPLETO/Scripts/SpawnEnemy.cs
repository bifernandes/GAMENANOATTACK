using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    private int random;
    private float spawnTime = 1f;
    private float spawnDelay = 1.5f;
    
    
    private void Start()
    {
        InvokeRepeating("SpawnRandom", spawnTime, spawnDelay);            
    }
    
    void SpawnRandom()
    {
        random = Random.Range(0, enemies.Length);
        Instantiate(enemies[random], transform.position, transform.rotation);
    }
}

