using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject player;
    public const int LEVELS = 2;
    public List<string> cams = new List<string>(LEVELS);
    public List<string> resets = new List<string>(LEVELS);
    public Jetpack jp;
    private TimeJump tj;
    public List<GameObject> matsToS = new List<GameObject>();

    public float world;
    public int currentLevel;
 

    // Start is called before the first frame update
    void Start()
    {


        tj = player.GetComponent<TimeJump>();
       for(int i = 1; i <= FindObjectsOfType<Camera>().Length; i++)
       {
            cams.Add("Level" + world + "-"+ i);
            resets.Add("SpawnPoint" + i);
       }
        cameraWork();
        restart();
    }

    
    public void restart()
    {

        resetMats();
       
        GameObject currentReset = GameObject.Find(resets[currentLevel]);
        player.transform.position = new Vector2(currentReset.transform.position.x, currentReset.transform.position.y);
    }

    private void resetMats()
    {
        tj.fuel = 0;
        jp.fuel = 0;
        foreach(GameObject mat in matsToS)
        {
            mat.SetActive(true);
        }
        matsToS.Clear();


    }

    public void cameraWork()
    {
        //GameObject currentCam = GameObject.Find(cams[currentLevel]);
        //currentCam.GetComponent<Camera>().enabled = false;
        for(int i = 0; i < cams.Count; i++)
        {

            Debug.Log("Cmaera "+ i + "is" + (i == currentLevel));
            if(i == currentLevel)
            {
                GameObject.Find(cams[i]).GetComponent<Camera>().enabled = true;
                //starting spot for camera on each sub level
                GameObject.Find(cams[i]).GetComponent<Camera>().transform.position = new Vector3(player.transform.position.x, 0, -2);
            }
            else
            {
                GameObject.Find(cams[i]).GetComponent<Camera>().enabled = false;
            }   
        }
    }
}
