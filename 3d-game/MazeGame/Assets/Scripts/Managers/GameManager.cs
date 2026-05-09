using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int lastGameSceneIndex;
    public static string lastGameScene;
    public GameObject AnnoyingCompanion;

    [Header("Key Settings")]
    public int totalKeys = 3;
    private int keysCollected = 0;

    [Header("Exit")]
    public GameObject exit;

    [Header("Timer")]
    public float levelTime = 300f;
    private float timeRemaining;
    private bool timerRunning = false;
    private bool gameOver = false;

    [Header("UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI keysText;
    public TextMeshProUGUI allKeysText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (exit != null)
            exit.SetActive(false);

        timeRemaining = levelTime;
        timerRunning = true;

        lastGameScene = SceneManager.GetActiveScene().name;
        lastGameSceneIndex = SceneManager.GetActiveScene().buildIndex;

        UpdateKeysUI();
    }

    void Update()
    {
        if (!timerRunning) return;

        timeRemaining -= Time.deltaTime;
        UpdateTimerUI();

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            timerRunning = false;
            LoseGame();
        }
    }

    void UpdateTimerUI()
    {
        if (timerText == null) return;
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float GetTimeRemaining() => timeRemaining;

    public void KeyCollected()
    {
        keysCollected++;
        UpdateKeysUI();
        Debug.Log("Keys: " + keysCollected + "/" + totalKeys);
        if (keysCollected >= totalKeys)
            UnlockExit();
    }

    void UpdateKeysUI()
    {
        if (keysText != null)
            keysText.text = "Keys: " + keysCollected + " / " + totalKeys;
    }

    void UnlockExit()
    {
        Debug.Log("Exit unlocked!");
        if (exit != null)
            exit.SetActive(true);
        if (allKeysText != null)
        {
            allKeysText.text = "You have collected all the keys, exit unlocked";
            allKeysText.gameObject.SetActive(true);
            StartCoroutine(HideAllKeysText());
        }
    }

    IEnumerator HideAllKeysText()
    {
        yield return new WaitForSeconds(4f);
        if (allKeysText != null)
            allKeysText.gameObject.SetActive(false);
    }

    public void WinGame()
    {
        if (gameOver) return;
        gameOver = true;
        timerRunning = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("You Win!");
        StartCoroutine(LoadScene("WinScreen"));
    }

    public void LoseGame()
    {
        if (gameOver) return;
        gameOver = true;
        timerRunning = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
          // Trigger companion death sequence
        FindFirstObjectByType<AnnoyingCompanion>()?.OnPlayerDeath();
        Debug.Log("You Lose!");
        AudioManager.Instance?.PlaySFX(AudioManager.Instance?.DeathHit);
        StartCoroutine(LoadScene("LoseScreen"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(lastGameScene);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}