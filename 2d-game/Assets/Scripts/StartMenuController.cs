using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public GameObject stageSelectionPanel; // 👈 assign in Inspector

    public void OnStartClick()
    {
        stageSelectionPanel.SetActive(true); // show stages instead of loading directly
    }

    public void LoadStage(string stageName)
    {
        Time.timeScale = 1f; // important if coming from paused game
        SceneManager.LoadScene(stageName);
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}