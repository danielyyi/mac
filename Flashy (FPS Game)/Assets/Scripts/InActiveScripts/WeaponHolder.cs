using UnityEngine;

public class WeaponHolder : MonoBehaviour
{

    public int selectedWeapon = 0;    
    public GameObject ejectedGun;
    public Transform gunReserve;
    public GameObject secondary;
  
   
    
    
        
  

    void Start()
    {
        SelectWeapon();
        
    }

    void Update()
    {
        //Select Weapon In Hierarchy (Scroll Wheel, etc.)
        int previousSelectedWeapon = selectedWeapon;
    
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&& transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

        Transform[] allChildren = GetComponentsInChildren<Transform>();
        
        //sends the weapon to reserve gun bank. 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ejectedGun = this.transform.GetChild(1).gameObject;
            ejectedGun.SetActive(false);
            secondary.SetActive(false);
            selectedWeapon = 0; 
            SetNewParent();
        }

    }
    void SetNewParent()
    {       
        ejectedGun.transform.SetParent(gunReserve);
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);  
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
