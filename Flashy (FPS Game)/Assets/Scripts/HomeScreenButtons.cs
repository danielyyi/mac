using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenButtons : MonoBehaviour
{
    public GameObject questionScreen;
    public GameObject creditsScreen;
    public GameObject settingsScreen;


    private void Start()
    {
        questionScreen.SetActive(false);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene("Arena #1");
    }

    public void Settings()
    {
        settingsScreen.SetActive(true);
        
    }
    public void SettingsOFF()
    {
        settingsScreen.SetActive(false);
    }
    public void QuestionScreenON()
    {
        questionScreen.SetActive(true);
    }

    public void QuestionScreenOFF()
    {
        questionScreen.SetActive(false);
    }

    public void CreditScreenON()
    {
        creditsScreen.SetActive(true);
    }

    public void CreditsScreenOFF()
    {
        creditsScreen.SetActive(false);
    }

    public void Leave()
    {
        Application.Quit();
    }

}
