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
        SceneManager.LoadScene("Maze2");
    }

    public void LoadLevel3()
    {
        AudioManager.Instance?.PlayButtonClick();
        SceneManager.LoadScene("Maze3");

    }

    public void GoBack()
    {
        AudioManager.Instance?.PlayButtonClick();
        SceneManager.LoadScene("MainMenu");
    }
}