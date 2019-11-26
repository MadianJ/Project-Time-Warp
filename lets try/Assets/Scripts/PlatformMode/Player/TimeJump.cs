using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeJump : MonoBehaviour
{
    public GameObject present;
    public GameObject past;

  
    public float fuel;
    public float maxFuel;

    private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
        tr.time =0f;
        present.SetActive(true);
        past.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (present.active)
            tr.Clear();
        if (Input.GetButtonUp("Fire2") )
        {
            if (fuel > 0 && present.active)
            {
                goToPast();
            }
            else 
            {
                goToPresent();
            }

        }

    }
    private void LateUpdate()
    {
        if (past.active)
        {
            fuel -= Time.deltaTime;
            if (fuel<= 0)
            {
                goToPresent();
            }
        }

        
    }

    void goToPast()
    {
        tr.time = 1f;
        present.SetActive(false);
        past.SetActive(true);
    }
    void goToPresent()
    {

        present.SetActive(true);
        past.SetActive(false);
    }
}
