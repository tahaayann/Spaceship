using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 5;
    public float playerHealth;

    public bool hitImmunity = false;
    public bool playerFlash = false;
    public float hitImmunityDuration;
    public float dashImmunityDuration;

    void Start()
    {
        playerHealth = maxHealth;
    }

  


    public void TakeDamage(int damage)
    {
        while (!hitImmunity)
        {
            playerHealth -= damage;
            Debug.Log("Player hit");
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            HitImmunity();

        }
        if (playerHealth <= 0)
        {
            Debug.LogWarning("PlayerDefeated");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }

    public void HitImmunity()
    {
        hitImmunity = true;
        playerFlash = true;
        Invoke("ResetImmunity", hitImmunityDuration);

    }

    public void DashImmunity()
    {
        if (!hitImmunity)
        {
            hitImmunity = true;
            Invoke("ResetImmunity", dashImmunityDuration);

        }

    }
    private void ResetImmunity()
    {
        hitImmunity = false;
        playerFlash= false;

    }

}
