using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f, player.GetComponent<Rigidbody2D>().velocity.y);
       if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    public void loseHP()
    {
        Debug.Log("ouchie");
        hp--;
    }
}
