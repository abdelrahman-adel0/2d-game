using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // ── Reset statics on every domain reload (fixes "invalid GC handle" spam) ──
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetStatics()
    {
        Instance           = null;
        lastGameScene      = null;
        lastGameSceneIndex = 0;
    }

    public static GameManager Instance;
    public static int lastGameSceneIndex;

    [Header("Key Settings")]
    public int totalKeys = 3;
    private int keysCollected = 0;

    [Header("Exit")]
    public GameObject exit;

    [Header("Timer")]
    public float levelTime = 900f; // 3 minutes default
    private float timeRemaining;
    private bool timerRunning = false;

    [Header("UI Screens")]
    public GameObject winScreen;
    public GameObject loseScreen;
    public TextMeshProUGUI timerText;

    // Store the game scene name so LoseScreen can access it
    public static string lastGameScene;
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

        lastGameScene = SceneManager.GetActiveScene().name;
        lastGameSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("You Win!");
        StartCoroutine(LoadWinScreen());
    }

    IEnumerator LoadWinScreen()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("WinScreen");
        yield return asyncLoad;
    }
    
    public void LoseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        timerRunning = false;
        Debug.Log("You Lose!");
        AudioManager.Instance?.PlaySFX(AudioManager.Instance?.DeathHit);
        StartCoroutine(LoadLoseScreen());
    }

    IEnumerator LoadLoseScreen()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LoseScreen");
        yield return asyncLoad;
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