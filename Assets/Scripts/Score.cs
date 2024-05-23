using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    private float baseHeight;
    private float maxHeightReached;

    [SerializeField] private PlayerMovement player;

    private void Start()
    {
        baseHeight = player.transform.position.y;
        maxHeightReached = baseHeight;

        scoreText.text = "SCORE: " + score.ToString();
    }

    private void Update()
    {
        // Check if the player has reached a new maximum height
        if (player.transform.position.y > maxHeightReached)
        {
            maxHeightReached = player.transform.position.y;
            // Calculate the score based on the maximum height reached
            score = Mathf.FloorToInt(maxHeightReached - baseHeight);
            // Update the score text
            scoreText.text = "SCORE: " + score.ToString();
        }
    }
}
