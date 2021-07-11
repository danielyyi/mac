using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrateSpawner : MonoBehaviour
{
    public AudioSource regSound;
    public AudioSource fifthSound;
    public static bool oneDead = false;
    public static float cratesAmt = 0;
    public static bool allGone;
    public TextMeshProUGUI cratesText;
    public GameObject crate;
    Vector3 spawnArea1;
    Vector3 spawnArea2;
    Vector3 spawnArea3;

    [Header("Spawn 1 Values")]
    public float spawn1amt = 5;
    public float spawn1x_min = -5;
    public float spawn1x_max = 10;

    public float spawn1y = 5;

    public float spawn1z_min = -4.5f;
    public float spawn1z_max = .5f;

    [Header("Spawn 2 Values")]
    public float spawn2amt = 5;
    public float spawn2x_min = -4.8f;
    public float spawn2x_max = 18.82f;

    public float spawn2y = 7.32f;

    public float spawn2z_min = 4.19f;
    public float spawn2z_max = 15.88f;

    [Header("Spawn 3 Values")]
    public float spawn3amt = 5;
    public float spawn3x_min = 22.1f;
    public float spawn3x_max = 27.5f;

    public float spawn3y = 4.1f;

    public float spawn3z_min = -6.1f;
    public float spawn3z_max = 16.3f;



    public void Start()
    {
        cratesAmt = 0;
        Spawn1(spawn1amt);
        Spawn2(spawn2amt);
        Spawn3(spawn3amt);
    }

    private void Update()
    {
        if(cratesAmt == 15)
        {
            allGone = true;
        }

        if(oneDead == true)
        {
            if((cratesAmt%5) == 0)
            {
                fifthSound.Play();
            }
            else
            {
                regSound.Play();
            }
            
            oneDead = false;
        }
        

        cratesText.text = cratesAmt.ToString() + "/15";
    }

    public void Spawn1(float amt)
    {
        for(int i = 0; i<amt; i++)
        {
            spawnArea1 = new Vector3(Random.Range(spawn1x_min, spawn1x_max), spawn1y, Random.Range(spawn1z_min, spawn1z_max));
            Instantiate(crate, spawnArea1, Quaternion.identity);
        }
        
    }

    public void Spawn2(float amt)
    {
        for (int i = 0; i < amt; i++)
        {
            spawnArea2 = new Vector3(Random.Range(spawn2x_min, spawn2x_max), spawn2y, Random.Range(spawn2z_min, spawn2z_max));
            Instantiate(crate, spawnArea2, Quaternion.identity);
        }
    }

    public void Spawn3(float amt)
    {
        for (int i = 0; i < amt; i++)
        {
            spawnArea3 = new Vector3(Random.Range(spawn3x_min, spawn3x_max), spawn3y, Random.Range(spawn3z_min, spawn3z_max));
            Instantiate(crate, spawnArea3, Quaternion.identity);
        }
    }
}
