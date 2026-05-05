using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    private int score = 0;
    private int highscore = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
        }

        UpdateUI();
    }
    
    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("Highscore");
        highscore = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = score + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore;
    }
}
