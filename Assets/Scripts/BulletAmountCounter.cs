using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BulletAmountCounter : MonoBehaviour
{
    public float amount;

    public TextMeshProUGUI textMeshPro;
    public Weapon weapon;
    public float bulletCounter = 0;

    public void Start()
    {
        weapon = FindObjectOfType<Weapon>();
    }

    void Update()
    {
        bulletCounter = weapon.bulletAmount;
        if (bulletCounter  is 4 or 5)
        {
            textMeshPro.color = Color.yellow;
        }
        else if (bulletCounter <= 3) { textMeshPro.color = Color.red; } else { textMeshPro.color = Color.white;}

        textMeshPro.text =  bulletCounter.ToString();
    }
}
