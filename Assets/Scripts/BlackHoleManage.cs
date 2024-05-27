using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleManage : MonoBehaviour
{
    [SerializeField] private float dragForce;

    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private Transform point3;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(point1.position, point2.position);
        Gizmos.DrawLine(point2.position, point3.position);
        Gizmos.DrawLine(point3.position, point1.position);
    }
}
