using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                Debug.Log("game is paused");
            }
            else
            {
                Pause();
                Debug.Log("game is resumed");
            }
        }

    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void Options()
    {
        Debug.Log("option menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResumeButton()
    {
        Resume();
    }

    public void Menus()
    {
        Debug.Log("go to menus");
    }
}
