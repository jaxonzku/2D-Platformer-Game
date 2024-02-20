using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int score=0;
    public int increment;
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUI();
    }

    public void IncrementScore(int increment)
    {
        score += increment;
        RefreshUI();
    }
    private void RefreshUI()
    {
        scoreText.text = "Score : " + score;
    }
}
