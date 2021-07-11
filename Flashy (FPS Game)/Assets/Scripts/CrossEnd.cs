using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrossEnd : MonoBehaviour
{
    public static bool isDone;
    public GameObject player;
    public GameObject spawner;
    public GameObject crossStart;
    public GameObject pressE;
    public TextMeshProUGUI highscoreText;
    public GameObject highscoreHolder;

    private void Start()
    {
        pressE.SetActive(false);
        highscoreHolder.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (CrateSpawner.allGone == true)
        {
            isDone = true;
            CrossStart.isCounting = false;
            CompareScore(CrossStart.timer);
            
        }
        else
        {
            isDone = false;
        }
    }

    private void Update()
    {
        if(isDone == true )
        {
            pressE.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {

                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                pressE.SetActive(false);
                CrateSpawner.cratesAmt = 0;
                player.transform.position = new Vector3(14.63f, 1.12f, -40f);
                CrossStart.timer = 0;
                spawner.GetComponent<CrateSpawner>().Start();
                crossStart.GetComponent<CrossStart>().Update();
                highscoreHolder.SetActive(false);

                isDone = false;
            }
        }
    }

    void CompareScore(float currentScore)
    {
        highscoreHolder.SetActive(true);
        if (currentScore < PlayerPrefs.GetFloat("Highscore", 999))
        {
            PlayerPrefs.SetFloat("Highscore", currentScore);
            highscoreText.text = (Mathf.Round(currentScore * 100f) * 0.01f).ToString() + "s";
        }
        else
        {
            highscoreText.text = (Mathf.Round(PlayerPrefs.GetFloat("Highscore", 0) * 100f) * .01f).ToString() + "s";
        }
    }



}
