using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    private RectTransform reticle;

    public float restingSize;
    public float maxSize;
    public float speed;
    private float currentSize;
    public float amount;
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;


    void Start()
    {
        reticle = GetComponent<RectTransform>();
    }

  
    void Update()
    {
        if (isMoving)
        {
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed);  
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize, restingSize, Time.deltaTime * speed);
        }

        if (Input.GetButton("Fire2"))
        {
            c3.SetActive(false);
            c2.SetActive(false);
            c1.SetActive(false);
            c4.SetActive(false);          
        }
        else
        {
            c3.SetActive(true);
            c2.SetActive(true);
            c1.SetActive(true);
            c4.SetActive(true);
        }

        reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }

    bool isMoving
    {
        get
        {
            if ((Input.GetAxis("Horizontal") >amount || (Input.GetAxis("Vertical") >amount)||(Input.GetAxis("Horizontal") < -amount || (Input.GetAxis("Vertical") < -amount))))
            {
                 
                return true;
            }

            else
                return false;
        }
    }
}
