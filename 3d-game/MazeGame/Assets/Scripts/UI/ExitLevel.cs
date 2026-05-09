using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

