using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Image currentStaminaBar;
    public Image fullStaminaBar;
    public CharacterController characterController;

    private float targetFillAmount = 0.65f;  // Bar�n hedef doluluk miktar�
    private float currentFillAmount = 0.65f;  // Ba�lang��ta tam dolu
    private float elapsedTime = 0f;  // Ge�en s�re

    private bool isFilling = false;  // Bar�n dolmaya ba�lamak i�in kontrol

    private void Start()
    {
        // Ba�lang��ta bar tam dolu
        fullStaminaBar.fillAmount = targetFillAmount;
    }

    private void Update()
    {
        // Dash ba�lad�ysa ve bar dolmaya ba�lamam��sa
        if (characterController.isDashing && !isFilling)
        {
            isFilling = true;  // Bar dolmaya ba�las�n
            elapsedTime = 0f;  // Zaman� s�f�rla
        }

        if (isFilling)
        {
            fullStaminaBar.fillAmount = 0f;
            FillStamina();  // Bar� doldur
            

        }
    }

    void FillStamina()
    {
        // Bar dolmaya ba�l�yor ve tamamlanana kadar devam etmesi gerekiyor
        float fillDuration = characterController._dashCooldown;

        if (elapsedTime < fillDuration)
        {
            elapsedTime += Time.deltaTime;
            currentFillAmount = Mathf.Lerp(0f, targetFillAmount, elapsedTime / fillDuration);
            currentStaminaBar.fillAmount = currentFillAmount;
        }
        else
        {
            // Bar tamamen doldu�unda
            currentFillAmount = targetFillAmount;
            currentStaminaBar.fillAmount = currentFillAmount;

            // Bar�n dolmas�n� durdur
            isFilling = false;
            fullStaminaBar.fillAmount = targetFillAmount;

        }



    }
}
