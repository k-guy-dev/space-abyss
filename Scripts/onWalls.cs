using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onWalls : MonoBehaviour
{
    public GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gm.ls_ms = true;
          
            
        }
    }
}
