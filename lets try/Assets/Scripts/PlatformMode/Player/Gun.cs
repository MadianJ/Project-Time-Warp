using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    
    public Transform shootingPoint;
    public LayerMask shootable;
    private LineRenderer lazer;
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        lazer = GetComponentInChildren<LineRenderer>();
        lazer.SetColors(Color.yellow, Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        lazer.enabled = false;
       
       Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );

        transform.up = -direction;

      if(Input.GetAxisRaw("Fire1") > 0)
        {
            lazer.enabled = true;
            lazer.SetPosition(0, shootingPoint.position);
            lazer.SetPosition(1, mousePosition);
           // Debug.DrawRay(shootingPoint.position, direction);

            RaycastHit2D fire = Physics2D.Raycast(shootingPoint.position, direction, 6f, shootable);

            if (fire)
            {
               
                Mats mat = fire.transform.GetComponent<Mats>();
                if(mat != null)
                {
                    mat.takeDamage(Damage, direction);
                }
            }

        }

    }
}

