using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Maze1");
    }

    public void LoadLevel2()
    {
        // Scene not ready yet — shows message in editor
        Debug.Log("Level 2 coming soon!");
        // SceneManager.LoadScene("Maze2"); // uncomment when ready
    }

    public void LoadLevel3()
    {
        // Scene not ready yet — shows message in editor
        Debug.Log("Level 3 coming soon!");
        // SceneManager.LoadScene("Maze3"); // uncomment when ready
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}