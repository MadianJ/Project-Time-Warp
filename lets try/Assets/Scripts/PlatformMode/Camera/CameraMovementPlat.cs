using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementPlat : MonoBehaviour
{
    public float  stopX1;
    public float stopX2;
    public float offsetY;
    public float offsetZ;
    private GameObject player;
    bool canGoRight;
    bool canGoLeft;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.transform.position.x > stopX1) {
            canGoLeft = true;
        }
        else
        {
            canGoLeft = false;
        }

        if(player.transform.position.x < stopX2)
        {
            canGoRight = true;
        }
        else
        {
            canGoRight = false;
        }
     
    }


    private void LateUpdate()
    {
        if (canGoRight && canGoLeft)
        {
            this.transform.position = new Vector3(player.transform.position.x, offsetY, offsetZ);
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, offsetY, offsetZ);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
