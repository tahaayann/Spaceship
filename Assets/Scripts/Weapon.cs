using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;


    public float bulletAmount = 15;

    public float bulletForce;
    public float fireRate = 1f;
    public float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bulletAmount > 0 || Input.GetKeyDown(KeyCode.JoystickButton0) && bulletAmount > 0)
        {
            if (Time.time>= nextFireTime)
            {
                Shoot();
                bulletAmount = bulletAmount - 1;
                nextFireTime = Time.time + fireRate;
            }
        }
    }
   
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        FindObjectOfType<AudioManager>().Play("WeaponFire");
        
    }

}
