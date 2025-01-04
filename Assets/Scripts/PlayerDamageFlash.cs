using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageFlash : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float flashDuration = 0.1f;

    public Coroutine flashCoroutine;
    public PlayerHealth playerHealth;

    public CharacterController characterController;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        if (spriteRenderer == null)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); 

        }
        
    }

    private void Update()
    {
        if (playerHealth.playerFlash && flashCoroutine == null)
        {
            flashCoroutine = StartCoroutine(FlashRoutine());
        }

        if (!playerHealth.playerFlash && flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
            flashCoroutine = null;

            spriteRenderer.enabled = true;
        }
    }
    
    public IEnumerator FlashRoutine()
    {
        while (playerHealth.hitImmunity == true)
        {
            FindObjectOfType<AudioManager>().Play("PlayerFlash");
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(flashDuration);

            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(flashDuration);

        }
        

    }
}
