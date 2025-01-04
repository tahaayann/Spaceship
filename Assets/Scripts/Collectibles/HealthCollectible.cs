using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : Collectible
{
    public PlayerHealth PlayerHealth;

    public override void ApplyEffect(GameObject player)
    {
        PlayerHealth.playerHealth += 1;
    }
}
