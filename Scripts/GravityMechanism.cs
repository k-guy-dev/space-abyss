using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMechanism : MonoBehaviour
{
    Rigidbody rb;
    public float target_radius = 35;
    public float pull_force = 100;
    public float rotational_force = 300;
    public bool launch = false;
    public PlayerBallScript pbs;
    public bool stopPlayer = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        pbs = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBallScript>();
    }

    void Update()
    {
        foreach (Collider collider in Physics.OverlapSphere(transform.position, target_radius))
        {
            if(collider.tag == "Player")
            {
                //linear attraction
                Vector3 force_direction = transform.position - collider.transform.position;
                // collider.attachedRigidbody.AddForce(force_direction.normalized * pull_force * Time.deltaTime);
                if (!launch)
                {
                    collider.transform.RotateAround(transform.position, Vector3.up, rotational_force * Time.deltaTime);

                }

                if (collider.tag == "Player")
                {
                    pbs.inOrbit = true;
                    pbs.justEntered = true;

                }
                if (pbs.justEntered == true)
                {
                    collider.attachedRigidbody.velocity = collider.attachedRigidbody.velocity / 2;
                    pbs.justEntered = false;
                }
            }
            
        }
       
    }
    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, target_radius);
    }
}
