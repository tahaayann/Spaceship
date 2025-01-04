using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image totalHealthBar;
    public Image currentHealthBar;


    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.playerHealth / 10;
        totalHealthBar.fillAmount = playerHealth.maxHealth / 10;

    }


}
