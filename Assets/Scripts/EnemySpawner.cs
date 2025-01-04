using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1.5f;
    public Vector2 spawnDirection = Vector2.down;
    public float launchSpeed = 5f;
    public int spawnAmount;
    public float invokeDelay;

    void Start()
    {
        
        InvokeRepeating("SpawnEnemy", invokeDelay, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (spawnAmount > 0)
        {
            spawnAmount--;
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = spawnDirection.normalized * launchSpeed;

            }
        }
        else { Destroy(gameObject); }
        
    }
}
