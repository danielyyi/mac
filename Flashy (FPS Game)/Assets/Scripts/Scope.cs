using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverlay;
    public GameObject crosshair;
    public Camera mainCamera;
    public GameObject weaponCamera;
    public float scopedFOV = 15f;
    public float normalFOV = 60f;

    private void Update()
    {  
        if(Input.GetButton("Fire2"))
        {     
            animator.SetBool("Scoping", true);
            StartCoroutine(OnScoped());      
        }
        else
        {
            animator.SetBool("Scoping", false);
            StartCoroutine(OnUnScoped());
        }
    }

    IEnumerator OnUnScoped()
    {
        yield return new WaitForSeconds(.1f);
        crosshair.SetActive(true);  
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
    }
    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.1f);
        crosshair.SetActive(false);
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);     
    }
}
