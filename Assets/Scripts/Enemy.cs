using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyDamageFlash enemyDamageFlash;
    public GameObject ammoCollectiblePrefab;
    public GameObject healthCollectiblePrefab;
    public Score Score;

    public int enemyMaxHealth = 2;
    public int enemyHealth;
    public int damage = 1;

    public float ammoDropChance = 0.5f;
    public float healthDropChance = 0.5f;

    void Start()
    {
        enemyHealth = enemyMaxHealth;
        enemyDamageFlash = GetComponent<EnemyDamageFlash>();
        Score = FindAnyObjectByType<Score>();
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        CharacterController controller = collision.GetComponent<CharacterController>();

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);

        }
    }

    public void TakeDamage(int damage)
    {
        enemyDamageFlash.TriggerFlash();

        FindObjectOfType<AudioManager>().Play("EnemyHit");


        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Score.score += 1;
            Destroy(gameObject, enemyDamageFlash.duration);
            DropItem();
        }

    }

    public void DropItem()
    {
        float randAmmo = Random.Range(0f, 1f);
        if (randAmmo < ammoDropChance)
        {
            Instantiate(ammoCollectiblePrefab, transform.position, Quaternion.identity);
            return; 
        }

        float randHealth = Random.Range(0f, 1f);
        if (randHealth < healthDropChance)
        {
            Instantiate(healthCollectiblePrefab, transform.position, Quaternion.identity);
        }

    }

}
