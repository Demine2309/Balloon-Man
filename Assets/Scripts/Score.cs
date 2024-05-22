using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    private float playetHeight = 1f;

    [SerializeField] private PlayerMovement player;

    private void Start()
    {

    }

    private void Update()
    {
        scoreText.text = score.ToString();

        float currentHeight = player.transform.position.y;

        currentHeight = Mathf.Max(0f, currentHeight);


    }
}
