using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        AudioManager.Instance?.PlaySFX(AudioManager.Instance?.LoseLaugh);
    }

    public void ReplayLevel()
    {
        AudioManager.Instance?.PlayButtonClick();
        string sceneToLoad = GameManager.lastGameScene;

        if (!string.IsNullOrEmpty(sceneToLoad))
            SceneManager.LoadScene(sceneToLoad);
        else
            SceneManager.LoadScene("Maze1"); // fallback
    }

    public void LoadMainMenu()
    {
        AudioManager.Instance?.PlayButtonClick();
        SceneManager.LoadScene("MainMenu");
    }
}