using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float MAX_FORCE = 100f;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float holdForce = 0f;
    [SerializeField] private float dragForce = 0f;

    private Rigidbody2D rb;
    private Coroutine holdForceCoroutine;

    private void Awake()
    {
        transform.position = new Vector3(0, -3.85f, 0);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerRotatation();
        MoveForward();
    }

    private void PlayerRotatation()
    {
        if (holdForce == 0)
        {
            float rotationSpeed = 90;

            if (Input.GetKey(KeyCode.A))
                rb.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.D))
                rb.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }

    private void MoveForward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (holdForce < MAX_FORCE)
            {
                if (holdForceCoroutine == null)
                    holdForceCoroutine = StartCoroutine(IncreaseHoldForce());
            }
            else
                ApplyForceAndResetHoldForce();
        }
        else if (holdForce > 0)
            ApplyForceAndResetHoldForce();
    }


    private void ApplyForceAndResetHoldForce()
    {
        Vector2 force = transform.up * holdForce * moveSpeed;
        rb.AddForce(force);

        rb.drag = dragForce;

        if (holdForceCoroutine != null)
        {
            StopCoroutine(holdForceCoroutine);
            holdForceCoroutine = null;
        }

        holdForce = 0f;
    }

    private IEnumerator IncreaseHoldForce()
    {
        while (holdForce < MAX_FORCE)
        {
            holdForce += 2;

            yield return null;
        }
    }

    public float GetHoldForce()
    {
        return holdForce;
    }
}
