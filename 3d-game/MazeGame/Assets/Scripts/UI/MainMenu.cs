using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadSceneAsync("Maze1");
    }

    public void OpenLevels()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        // For testing in editor:
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
