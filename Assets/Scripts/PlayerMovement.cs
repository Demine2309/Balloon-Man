using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        transform.position = new Vector3(0, 0, 0);

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        #region Using keyboard to move
        float rotationSpeed = 90;

        if (Input.GetKey(KeyCode.A))
            rb.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            rb.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        #endregion

        #region Using mouse to move
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
        Vector3 dirToMouse = mousePos - transform.position;

        transform.up = dirToMouse;
        #endregion
    }

    private void FixedUpdate()
    {
    }
}
