using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ADS : MonoBehaviour
{
    public Camera cam;
    public float zoomFOV = 20f;
    public float normalFOV = 60f;
    public float zoomSpeed = .5f;
    public Animator animator;
    public GameObject crosshair;
    public TextMeshPro adsCount;
    public static bool isADS;
 
    private void Update()
    {
        if (Input.GetButton("Fire2") && Gun.isReloading == false)
        {
            animator.SetBool("ADS", true);
            isADS = true;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomFOV, zoomSpeed);
        }
        else
        {      
            animator.SetBool("ADS", false);
            isADS = false;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, normalFOV, zoomSpeed);
        } 
    }
}
