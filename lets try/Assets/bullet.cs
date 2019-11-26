using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (speed *Time.deltaTime);
        Invoke("bye", 2f);
    }

    void bye()
    {
        Destroy(this.gameObject);
    }
}
