using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject nextLevelButton;

    private void Start()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        // If this is the final level
        if (currentIndex == 4)
        {
            nextLevelButton.SetActive(false);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentIndex + 1);
    }
}