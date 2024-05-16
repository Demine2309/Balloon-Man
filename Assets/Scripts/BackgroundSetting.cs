using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSetting : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    private Vector2 offset;
    private Material mat;
    private float time;

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
    }
}