using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void LoadLevel1()
    {
        AudioManager.Instance?.PlayButtonClick();
        SceneManager.LoadScene("Maze1");
    }

    public void LoadLevel2()
    {
        AudioManager.Instance?.PlayButtonClick();
        // Scene not ready yet — shows message in editor
        Debug.Log("Level 2 coming soon!");
        // SceneManager.LoadScene("Maze2"); // uncomment when ready
    }

    public void LoadLevel3()
    {
        AudioManager.Instance?.PlayButtonClick();
        // Scene not ready yet — shows message in editor
        Debug.Log("Level 3 coming soon!");
        // SceneManager.LoadScene("Maze3"); // uncomment when ready
    }

    public void GoBack()
    {
        AudioManager.Instance?.PlayButtonClick();
        SceneManager.LoadScene("MainMenu");
    }
}