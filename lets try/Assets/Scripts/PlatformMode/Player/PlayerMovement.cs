using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public float jumpForce;
    private bool grounded;
    Animator anim;



    public float horizVal;
 
    Spawning sp;
    GameObject wb;
    GameObject cB;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sp = Object.FindObjectOfType<Spawning>();
        wb = GameObject.Find("WayBackBar");
        cB = GameObject.Find("FuelBar");
    }

    // Update is called once per frame
    void Update()
    {
        horizVal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizVal * speed, rb.velocity.y);
        anim.SetInteger("SpeedX", (int)rb.velocity.x);
        anim.SetInteger("SpeedY", (int)rb.velocity.y);
     
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "WayBack")
        {
            wb.SetActive(true);
            if (GetComponent<TimeJump>().fuel / GetComponent<TimeJump>().maxFuel< 1)
                GetComponent<TimeJump>().fuel++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Coal")
        {
            cB.SetActive(true);
            if (GameObject.Find("JetpackP").GetComponent<Jetpack>().fuel / GameObject.Find("JetpackP").GetComponent<Jetpack>().maxFuel < 1)
            {
                GameObject.Find("JetpackP").GetComponent<Jetpack>().fuel += 1;
            }
            Destroy(collision.gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.tag);
        if (other.tag == "WayBack")
        {

            if (GetComponent<TimeJump>().fuel / GetComponent<TimeJump>().maxFuel < 1)
                GetComponent<TimeJump>().fuel++;
          // Destroy(other.GetComponent<par>());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "Fall" || collision.gameObject.tag == "Trap")
        {
            sp.restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
  
        if(collision.gameObject.tag == "Goal")
        {
            sp.currentLevel++;
            sp.restart();
            sp.cameraWork();
        }
        // Vector3 hitPosition = Vector3.zero;
        
    }


    


}
