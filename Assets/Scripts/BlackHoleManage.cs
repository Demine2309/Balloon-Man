using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleManage : MonoBehaviour
{
    public Transform target;
    [SerializeField] private List<Transform> points;

    [SerializeField] private float dragForce = 5f;

    private void Update()
    {
        for (int i = 1; i < points.Count; i++)
        {
            int layerMask = LayerMask.GetMask("Player");

            Vector2 direction = points[i].position - points[0].position; // Calculate direction vector

            float distance = direction.magnitude;

            Color rayColor = Color.green;

            RaycastHit2D hit = Physics2D.Raycast(points[0].position, direction, distance, layerMask);

            if (hit.collider != null)
            {
                rayColor = Color.red;
                Vector3 newPos = Vector3.MoveTowards(transform.position, target.position, dragForce * Time.deltaTime);
                transform.position = newPos;
            }
            else
                rayColor = Color.green;

            Debug.DrawRay(points[0].position, direction, rayColor);
        }
    }
}
