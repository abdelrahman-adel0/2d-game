using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameObject player;
    private GameObject[] enemies;

    public GameObject winPanel;
    public GameObject losePanel;
	private AudioManager audioManager;

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

		GameObject audioObj = GameObject.FindGameObjectWithTag("Audio");
		if (audioObj != null)
		{
    		audioManager = audioObj.GetComponent<AudioManager>();
		}
    }

    public void CheckWinState()
    {
        int aliveEnemies = 0;

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].activeSelf)
            {
                aliveEnemies++;
            }
        }

        // 🟢 WIN CONDITION
        if (aliveEnemies == 0)
        {
            WinGame();
        }
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);

		if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.Death);
        }
    }

    private void WinGame()
    {
        Time.timeScale = 0f;
        winPanel.SetActive(true);
		
		if (audioManager != null)
        	audioManager.PlayWin();

		FindFirstObjectByType<TimerManager>().enabled = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	public void GoToMenu()
	{
    	Time.timeScale = 1f;
    	SceneManager.LoadScene("Menu");
	}
}