using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject jetPackP;
    public GameObject player;

    public float maxFuel;
    public float fuel;
    public float jetPackSpeed;
    private float vertVal;
    public  TrailRenderer flame1;
    public TrailRenderer flame2;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        jetPackP.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        vertVal = Input.GetAxisRaw("Vertical");
       
        if (vertVal >= 1 && jetPackP.active)
        {
           
            fly();
        }
        else
        {
            flame1.Clear();
            flame2.Clear();
        }
    }




    void fly()
    {
        if (fuel > 0)
        {
            flame1.time = .1f;
            flame2.time = .1f;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 1 * jetPackSpeed);
            fuel -= Time.deltaTime;
        }
        else
        {
            flame1.Clear();
            flame2.Clear();
        }
    }

}
