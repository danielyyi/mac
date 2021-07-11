using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressEscape : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject escapeScreen;
    public GameObject player;
    public GameObject camPlayer;
    public GameObject gun;
    public GameObject crosshair;
    public bool isSettingsOpen = false;
    public bool isEscaped = false;

    private void Start()
    {
        settingsMenu.SetActive(false);
        escapeScreen.SetActive(false);

        gun.GetComponent<Gun>().enabled = true;
        camPlayer.GetComponent<PlayerCameraController>().enabled = true;
        player.GetComponent<PlayerMovementController>().enabled = true;
        Time.timeScale = 1;
        Cursor.visible = false;
        escapeScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        crosshair.SetActive(true);

    }
    private void Update()
    {
        if(settingsMenu.activeInHierarchy == true)
        {
            isSettingsOpen = true;
        }
        else
        {
            isSettingsOpen = false;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettingsOpen == false)
            {
                if (isEscaped == false)
                {
                    settingsMenu.SetActive(false);
                    isEscaped = true;
                    crosshair.SetActive(false);
                    gun.GetComponent<Gun>().enabled = false;
                    camPlayer.GetComponent<PlayerCameraController>().enabled = false;
                    player.GetComponent<PlayerMovementController>().enabled = false;
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    escapeScreen.SetActive(true);
                }
                else
                {
                    isEscaped = false;
                    XButton();
                }
            }
            
            else
            {
                if(isEscaped == true)
                {
                    settingsMenu.SetActive(false);
                }
            }
        }
    }

    public void XButton()
    {
        gun.GetComponent<Gun>().enabled = true;
        camPlayer.GetComponent<PlayerCameraController>().enabled = true;
        player.GetComponent<PlayerMovementController>().enabled = true;
        Time.timeScale = 1;
        Cursor.visible = false;
        escapeScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        crosshair.SetActive(true);
    }

    public void SettingsButton()
    {
        settingsMenu.SetActive(true);
    }

    public void ExitSettingsButton()
    {
        settingsMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void HomeScreen()
    {

        SceneManager.LoadScene("Home #1");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
