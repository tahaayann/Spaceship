using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : Collectible
{
    public PlayerHealth PlayerHealth;

    public void Start()
    {
        PlayerHealth = FindAnyObjectByType<PlayerHealth>();
    }

    public override void ApplyEffect(GameObject player)
    {
        if (PlayerHealth.playerHealth < PlayerHealth.maxHealth)
        {
            PlayerHealth.playerHealth += 1;
        }
    }
}
