using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GoPage2()
    {
        AudioManager.Instance?.PlayButtonClick();
        SceneManager.LoadScene("HowToPlay2");       
    }
    public void GoPage1()
    {
        AudioManager.Instance?.PlayButtonClick();
        SceneManager.LoadScene("HowToPlay1");       
    }
    public void GoToMainMenu()
    {
        AudioManager.Instance?.PlayButtonClick();
        SceneManager.LoadScene("MainMenu");       
    }
}