using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceBar : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Image forceBarImage;

    private const float MAX_FORCE = 100f;

    private void Update()
    {
        float currentForce = player.GetHoldForce();

        float fillAmount = currentForce / MAX_FORCE;

        forceBarImage.fillAmount = fillAmount;
    }
}
