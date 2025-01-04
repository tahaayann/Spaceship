using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollectible : Collectible
{
    public Weapon Weapon;

    public override void ApplyEffect(GameObject player)
    {
        Weapon.bulletAmount += Random.Range(3,5);
    }
}
