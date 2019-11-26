using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUnlock : MonoBehaviour
{
    public GameObject jetPackP;


    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            putJetPackOnPlayer();
            GameObject.Find("JetPack").SetActive(false);
        }
    }

    void putJetPackOnPlayer()
    {
        jetPackP.SetActive(true);
    }
}
