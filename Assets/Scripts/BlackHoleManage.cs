using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleManage : MonoBehaviour
{
    [SerializeField] private float dragForce;

    [SerializeField] private List<Transform> points;


    private void Update()
    {
        for (int i = 1; i < points.Count; i++)
        {
            int layerMask = LayerMask.GetMask("Player");

            Vector2 direction = points[i].position - points[0].position;

            RaycastHit2D hit = Physics2D.Raycast(points[0].position, direction, 10f, layerMask);

            Color rayColor = Color.green;

            if (hit.collider != null)
                rayColor = Color.red;
            else
                rayColor = Color.green;

            Debug.DrawRay(points[0].position, direction * 10f, rayColor);
        }
    }
}
