using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBar : MonoBehaviour
{


    
    private Transform bar;
    public string type;
    public GameObject comeback;
    private float percentLeft;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       
        bar = GetComponent<Transform>();
    }
    float changed;
    // Update is called once per frame
    void Update()
    {

        try
        {
            if (type == "WayBack")
            {
                TimeJump typeO = player
                    .GetComponent<TimeJump>();
                percentLeft = typeO.fuel / typeO.maxFuel;
            }
            else if (type == "JetPack")
            {
                Jetpack typeO = GameObject.Find("JetpackP").GetComponent<Jetpack>();
                percentLeft = typeO.fuel / typeO.maxFuel;
            }
            if( changed != percentLeft)
            {
               
               Invoke("hide", 2f);
            }
            changed = percentLeft;
            
            bar.localScale = new Vector3(1f, percentLeft);
        }
        catch
        {
            
        }
    }

    void hide()
    {
    

    }

}
