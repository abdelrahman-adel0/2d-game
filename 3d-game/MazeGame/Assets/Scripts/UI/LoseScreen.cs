using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public void ReplayLevel()
    {
        // Use the saved scene name from GameManager
        string sceneToLoad = GameManager.lastGameScene;

        if (!string.IsNullOrEmpty(sceneToLoad))
            SceneManager.LoadScene(sceneToLoad);
        else
            SceneManager.LoadScene("Game"); // fallback, rename to your actual scene name
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}