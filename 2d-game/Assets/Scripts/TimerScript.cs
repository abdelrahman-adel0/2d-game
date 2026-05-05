using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 300f; // 5 minutes
    public TMP_Text timerText;

    private bool isRunning = true;

    private void Update()
    {
        if (!isRunning) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            isRunning = false;

            GameManager.Instance.LoseGame(); // 💀 time up = lose
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("RemainingTime {0:00}:{1:00}", minutes, seconds);
        
        if (timeRemaining <= 30f)
        {
            timerText.color = Color.red;
        }
    }
}