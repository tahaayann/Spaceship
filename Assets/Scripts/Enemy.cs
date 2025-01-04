using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyDamageFlash enemyDamageFlash;

    public int enemyMaxHealth = 2;
    public int enemyHealth;
    public int damage = 1;

    void Start()
    {
        enemyDamageFlash = GetComponent<EnemyDamageFlash>();
        enemyHealth = enemyMaxHealth;
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
            Destroy(gameObject, enemyDamageFlash.duration);
        }

    }

}
