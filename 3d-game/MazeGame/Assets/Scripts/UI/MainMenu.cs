using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        AudioManager.Instance?.PlayButtonClick();
        SceneManager.LoadSceneAsync("Maze1");
    }

    public void OpenLevels()
    {
        AudioManager.Instance?.PlayButtonClick();
        SceneManager.LoadSceneAsync("LevelMenu");
    }

    public void HowToPlay()
    {
        AudioManager.Instance?.PlayButtonClick();
        SceneManager.LoadSceneAsync("HowToPlay1");
    }


    public void QuitGame()
    {
        AudioManager.Instance?.PlayButtonClick();
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
