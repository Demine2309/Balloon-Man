using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BackgroundSetting : MonoBehaviour
{
    [Range(-1f, 1f)]
    [SerializeField] private float scrollSpeed = 0.25f;
    private Vector2 offset;
    private Material mat;
    private float time;

    [SerializeField] private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        offset = Vector2.zero;
        time = 0f;
    }

    private void Update()
    {
        time += Time.deltaTime * scrollSpeed;
        offset.x = Mathf.Cos(time) / 10f;
        offset.y = Mathf.Sin(time) / 10f;
        mat.SetTextureOffset("_MainTex", offset);

        Vector3 targetPosition = target.position + (Vector3)target.GetComponent<Rigidbody2D>().velocity * Time.deltaTime;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}