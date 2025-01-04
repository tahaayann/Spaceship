using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamageFlash : MonoBehaviour
{
    public Material enemyMaterial;
    public Material flashMaterial;

    public SpriteRenderer spriteRenderer;
    public float duration = 0.1f;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyMaterial = spriteRenderer.material;
    } 

    public void TriggerFlash()
    {
        StartCoroutine(EnemyFlash());

    }

    public IEnumerator EnemyFlash()
    {
        spriteRenderer.material = flashMaterial;

        yield return new WaitForSeconds(duration);

        spriteRenderer.material = enemyMaterial;

    }
}
