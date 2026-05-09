using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject nextLevelButton;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Use the saved index from GameManager
        int completedIndex = GameManager.lastGameSceneIndex;

        // Hide next level button if it was the final level (index 4)
        if (nextLevelButton != null)
            nextLevelButton.SetActive(completedIndex != 6);
    }

    public void ReplayLevel()
    {
        AudioManager.Instance?.PlayButtonClick();
        if (!string.IsNullOrEmpty(GameManager.lastGameScene))
            SceneManager.LoadScene(GameManager.lastGameScene);
        else
            SceneManager.LoadScene("Maze1"); // fallback
    }

    public void LoadMainMenu()
    {
        AudioManager.Instance?.PlayButtonClick();
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadNextLevel()
    {
        AudioManager.Instance?.PlayButtonClick();
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentIndex + 1);
    }

}