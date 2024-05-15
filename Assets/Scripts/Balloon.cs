using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private const float MAX_FORCE = 100f;

    private Vector3 initialScale;
    [SerializeField] private float sizeBalloon;
    [SerializeField] private PlayerMovement player;

    private void Awake()
    {
        initialScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    private void Update()
    {
        float holdForce = player.GetHoldForce();

        float scale =  holdForce / MAX_FORCE;
        transform.localScale = initialScale * scale * sizeBalloon;
    }
}
