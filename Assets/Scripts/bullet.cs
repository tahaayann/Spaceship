using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class bullet : MonoBehaviour
{
    int damage = 1;
    public GameObject hitEffectPrefab;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Vector2 bulletRotation = transform.up;

            GameObject hitEffect = Instantiate(hitEffectPrefab, transform.position, quaternion.identity);
            hitEffect.transform.up = -bulletRotation;

            Destroy(hitEffect,1f);
            Destroy(gameObject);
        }else if(collision.gameObject.CompareTag("Border"))
            {
            Destroy(gameObject);
            }
    }
}
