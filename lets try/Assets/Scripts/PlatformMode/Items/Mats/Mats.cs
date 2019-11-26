using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class Mats : MonoBehaviour
{
    
    private int hp = 20;
    private Vector3 pos;
   
    public List<GameObject> fuelPrefs = new List<GameObject>();
   

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            destroy();
        }
    }
    public void takeDamage(int damage, Vector2 pos)
    {
        this.pos = pos;
        hp -= damage;

    }
    private void destroy()
    {
        GameObject.Find("SpawnPoints").GetComponent<Spawning>().matsToS.Add(this.gameObject);
        for (int i = 0; i < fuelPrefs.Count; i++)
        {
            float randomX = Random.RandomRange(-40, 40);
            float randomY = Random.RandomRange(-40, 40);
            Vector2 randomVec = new Vector2(Random.RandomRange(-0.5f,0.5f), Random.RandomRange(-0.5f, 0.5f));
            GameObject mClone = Instantiate(fuelPrefs[i], this.transform.position +(Vector3) randomVec, Quaternion.identity);
            mClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomX, randomY));
        }
        this.gameObject.SetActive(false);
        hp = 20;
        
    }

}
