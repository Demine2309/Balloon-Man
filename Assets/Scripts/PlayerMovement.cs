using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float MAX_FORCE = 100f;
    private const float MAX_STAMINA = 1000f;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float holdForce = 0f;
    [SerializeField] private float dragForce = 0f;
    [SerializeField] private float stamina = MAX_STAMINA;

    private Rigidbody2D rb;

    private void Start()
    {
        transform.position = new Vector3(0, 0f, 0);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerRotatation();

        if(stamina > 0)
        {
            MoveForward();
        }

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
                holdForce += 100 * Time.fixedDeltaTime;
                Debug.Log(holdForce);
                Debug.Log(stamina);
            }
            else
                ApplyForceAndResetHoldForce();
        }
        else if (holdForce > 0)
            ApplyForceAndResetHoldForce();
    }


    private void ApplyForceAndResetHoldForce()
    {
        if (stamina > 0)
        {
            Vector2 force = transform.up * holdForce * moveSpeed;
            rb.AddForce(force);

            rb.drag = dragForce;

            stamina -= holdForce;
            stamina = Mathf.Clamp(stamina, 0, MAX_STAMINA);

            holdForce = 0f;
        }
    }

    public float GetHoldForce()
    {
        return holdForce;
    }

    public float GetStamina()
    {
        return stamina;
    }

    public void AddStamina(float amount)
    {
        stamina += amount;
        stamina = Mathf.Clamp(stamina, 0, MAX_STAMINA);
    }
}

