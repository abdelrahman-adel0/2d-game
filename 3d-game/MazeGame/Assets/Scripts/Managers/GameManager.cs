using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Key Settings")]
    public int totalKeys = 3;
    private int keysCollected = 0;

    [Header("Exit")]
    public GameObject exit;

    [Header("Timer")]
    public float levelTime = 180f; // 3 minutes default
    private float timeRemaining;
    private bool timerRunning = false;

    [Header("UI Screens")]
    public GameObject winScreen;
    public GameObject loseScreen;
    public TextMeshProUGUI timerText;

    void Awake()
    {
    
      Instance = this;

    }

    void Start()
    {
        // Lock exit at start
        if (exit != null)
            exit.SetActive(false);

        // Hide screens
        if (winScreen != null)  winScreen.SetActive(false);
        if (loseScreen != null) loseScreen.SetActive(false);

        // Start timer
        timeRemaining = levelTime;
        timerRunning = true;
    }

    void Update()
    {
        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerRunning = false;
                LoseGame();
            }
        }
    }

    void UpdateTimerUI()
    {
        if (timerText == null) return;

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void KeyCollected()
    {
        keysCollected++;
        Debug.Log("Keys collected: " + keysCollected + "/" + totalKeys);

        // UIManager.Instance?.UpdateKeyCount(keysCollected, totalKeys);

        if (keysCollected >= totalKeys)
            UnlockExit();
    }

    void UnlockExit()
    {
        Debug.Log("All keys collected! Exit unlocked!");
        if (exit != null)
            exit.SetActive(true);
    }

    public void WinGame()
    {
        timerRunning = false;
        Debug.Log("You Win!");
        if (winScreen != null)
            winScreen.SetActive(true);
    }

    public void LoseGame()
    {
        timerRunning = false;
        Debug.Log("You Lose!");
        if (loseScreen != null)
            loseScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}