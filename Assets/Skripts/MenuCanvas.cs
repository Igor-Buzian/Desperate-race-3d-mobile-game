using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    [Header("Pause Menu")]
    public GameObject pauseMenuUI;
    public static bool GameIsStoped;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsStoped = false;
    }

    public void Restart()
    {
        SceneTransition.SwithToScene("scene_day");
    }

    public void LoadMenu()
    {
        SceneTransition.SwithToScene("Garage");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PauseMenu()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsStoped = true;
    }
}
