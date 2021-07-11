
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 10f;
    public float impactForce = 30f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    public static bool isReloading = false;

    private float nextTimeToFire = 0f;
    public bool isFullAuto;
    public AudioSource shoot;
    public AudioSource reload;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public TextMeshPro ammoDisplay;
    public TextMeshPro adsDisplay;
    public Animator animator;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);    
    }

    void Update()
    {
        ammoDisplay.text = currentAmmo.ToString();

        if (isFullAuto)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0 && (isReloading == false))
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
                animator.SetBool("Shooting", true);
            }
            else
            {
                animator.SetBool("Shooting", false);
            }

        }
        if (!isFullAuto)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0 && (isReloading == false))
            {
                nextTimeToFire = Time.time + 5f / fireRate;
                Shoot();
                animator.SetBool("Shooting", true);
            }
            else
            {
                animator.SetBool("Shooting", false);
            }
        }

        if (ADS.isADS == true)
        {
            adsDisplay.text = currentAmmo.ToString();
        }
        else
        {
            adsDisplay.text = "";
        }
        
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo)
        {
            StartCoroutine(Reload());
            return;        
        }
   
        if(isReloading)
        {           
            ammoDisplay.text = "...";     
        }
  
        if (currentAmmo <= 0)
        {
            currentAmmo = 1;
            StartCoroutine(Reload());
            return;
        }
    }
    
    IEnumerator Reload()
    {     
        isReloading = true;          
        Debug.Log("Reloading...");    
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("Reloading", false);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        shoot.Play();
        muzzleFlash.Play();
        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, .5f);
        }
       
    }
}
