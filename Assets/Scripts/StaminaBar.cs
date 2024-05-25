using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Image staminaBarImage;

    private const float MAX_STAMINA = 1000f;

    private void Update()
    {
        float currentStamina = player.GetStamina();

        float fillAmount = currentStamina / MAX_STAMINA;

        staminaBarImage.fillAmount = fillAmount;
    }
}
