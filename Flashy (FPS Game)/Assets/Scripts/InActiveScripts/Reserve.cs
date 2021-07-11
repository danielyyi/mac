using UnityEngine;

public class Reserve : MonoBehaviour
{

    public int selectedWeapon = 0;
    public GameObject ejectedGun;
    public Transform weaponHolder;
  
   

    


    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {

        Transform[] allChildren = GetComponentsInChildren<Transform>();

        
        if (Input.GetKeyDown(KeyCode.Q))
        {          
            ejectedGun = this.transform.GetChild(0).gameObject;
            
            ejectedGun.SetActive(true);
            SetNewParent();
        }

    }
    void SetNewParent()
    {
        
        ejectedGun.transform.SetParent(weaponHolder);
        
    }
    void SelectWeapon()
    {

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false); 

        }
    }
}
