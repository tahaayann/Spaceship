using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Image currentStaminaBar;
    public Image fullStaminaBar;
    public CharacterController characterController;

    private float targetFillAmount = 0.65f;  // Barýn hedef doluluk miktarý
    private float currentFillAmount = 0.65f;  // Baþlangýçta tam dolu
    private float elapsedTime = 0f;  // Geçen süre

    private bool isFilling = false;  // Barýn dolmaya baþlamak için kontrol

    private void Start()
    {
        // Baþlangýçta bar tam dolu
        fullStaminaBar.fillAmount = targetFillAmount;
    }

    private void Update()
    {
        // Dash baþladýysa ve bar dolmaya baþlamamýþsa
        if (characterController.isDashing && !isFilling)
        {
            isFilling = true;  // Bar dolmaya baþlasýn
            elapsedTime = 0f;  // Zamaný sýfýrla
        }

        if (isFilling)
        {
            fullStaminaBar.fillAmount = 0f;
            FillStamina();  // Barý doldur
            

        }
    }

    void FillStamina()
    {
        // Bar dolmaya baþlýyor ve tamamlanana kadar devam etmesi gerekiyor
        float fillDuration = characterController._dashCooldown;

        if (elapsedTime < fillDuration)
        {
            elapsedTime += Time.deltaTime;
            currentFillAmount = Mathf.Lerp(0f, targetFillAmount, elapsedTime / fillDuration);
            currentStaminaBar.fillAmount = currentFillAmount;
        }
        else
        {
            // Bar tamamen dolduðunda
            currentFillAmount = targetFillAmount;
            currentStaminaBar.fillAmount = currentFillAmount;

            // Barýn dolmasýný durdur
            isFilling = false;
            fullStaminaBar.fillAmount = targetFillAmount;

        }



    }
}
