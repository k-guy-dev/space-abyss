using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onAsteroid : MonoBehaviour
{
    public Rigidbody rb;
    public Transform player;
    public GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector3 plypos = player.position;
        rb.AddForce(plypos.normalized * 150f,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 10f);
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            gm.ls_as = true;
            
        }
    }
}
