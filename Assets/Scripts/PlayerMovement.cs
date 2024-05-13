using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float MAX_FORCE = 100f;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float holdForce = 0f;
    private bool forceApplied = false;

    private Rigidbody2D rb;

    private void Awake()
    {
        transform.position = new Vector3(0, 0, 0);

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerRotatation();
        MoveForward();
    }

    private void FixedUpdate()
    {
    }

    private void PlayerRotatation()
    {
        float rotationSpeed = 90;

        if (Input.GetKey(KeyCode.A))
            rb.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            rb.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
    }

    private void MoveForward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            StartCoroutine(IncreaseHoldForce());
            Debug.Log(holdForce);
        }
        else
        {
            if (holdForce > 0)
            {
                Vector2 force = transform.up * holdForce * moveSpeed;
                rb.AddForce(force);

                rb.drag = 2.5f;
            }

            StopAllCoroutines();
            holdForce = 0f;
        }
    }

    private IEnumerator IncreaseHoldForce()
    {
        while (true)
        {
            holdForce = Mathf.Min(holdForce + 5 * Time.deltaTime, MAX_FORCE);

            if (holdForce >= MAX_FORCE)
            {
                // Apply force
                Vector2 force = transform.up * holdForce * moveSpeed;
                rb.AddForce(force);

                // Reset holdForce
                holdForce = 0f;
            }

            yield return null;
        }
    }

    public float GetHoldForce()
    {
        return holdForce;
    }
}
