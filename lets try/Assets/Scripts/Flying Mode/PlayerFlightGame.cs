using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlightGame : MonoBehaviour
{
    Rigidbody2D rb;
    float horiz;
    float vert;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vert = Input.GetAxisRaw("Vertical");
        horiz = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horiz * speed, vert * speed);
    }
}
