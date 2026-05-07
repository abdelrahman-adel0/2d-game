using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    public void GoPage2()
    {
        SceneManager.LoadScene("HowToPlay2");       
    }
    public void GoPage1()
    {
        SceneManager.LoadScene("HowToPlay1");       
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");       
    }
}