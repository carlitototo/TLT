using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Photon.Pun;
using UnityEngine;

public class PauseMenu : MonoBehaviourPunCallbacks
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
            }
            else
            {
                Pause();
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
        PhotonNetwork.LoadLevel(0);
        PhotonNetwork.LeaveRoom();
        menuManager.Instance.OpenMenu("loading");

    }
}
