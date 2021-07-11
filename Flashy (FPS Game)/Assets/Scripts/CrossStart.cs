using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrossStart : MonoBehaviour
{

    public TextMeshPro timerDisplay;
    public TextMeshProUGUI timerDisplay2;
    public static float timer = 0;
    public static bool isCounting = false;

    private void Start()
    {
        timer = 0;
        isCounting = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        CrateSpawner.allGone = false;
        isCounting = true;

    }

    public void Update()
    {
        timerDisplay.text = ((Mathf.Round(timer * 100f)) * .01f).ToString() + "s";
        timerDisplay2.text = ((Mathf.Round(timer * 100f)) * .01f).ToString() + "s";
        if (isCounting == true)
        {
            timer += Time.deltaTime;
            
        }

    }
}
