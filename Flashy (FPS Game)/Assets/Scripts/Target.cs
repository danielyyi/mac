using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public void Update()
    {
        if (CrossEnd.isDone == true)
        {
            TakeDamage(50);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        
        if (health <= 0f)
        {
            Die();  
        }

        void Die()
        {
            Destroy(gameObject);
            CrateSpawner.cratesAmt++;
            CrateSpawner.oneDead = true;
            
        }
    }
}
