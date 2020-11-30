using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallScript : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 305f;
    public float radius = 10f;
    public bool inOrbit = true;
    public GravityMechanism mech;
    public bool justEntered = false;
    public TrailRenderer trail;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
        mech = GameObject.FindGameObjectWithTag("Moon").GetComponent<GravityMechanism>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //   rb.AddRelativeForce(-Vector3.forward * force ,ForceMode.Impulse);
        //}
        rb.AddTorque(transform.up * 20);

        Vector3 tp = transform.position;

        Vector3 capsule_end = new Vector3(tp.x, tp.y, -tp.z - 330);




        if (Input.GetKeyDown(KeyCode.Space))
        {
            mech.launch = true;
            trailRenderer();
            Invoke("trailRenderer", 2f);
        }
        if (mech.launch == true)
        {
            rb.AddRelativeForce(Vector3.forward * force,ForceMode.Impulse);
            rb.velocity = rb.velocity /10;
            
            
            foreach(Collider collider in Physics.OverlapCapsule(transform.position, capsule_end, 1f))
            {
                if(collider.tag == "Moon")
                {
                    transform.localRotation = Quaternion.EulerRotation(0f, transform.rotation.y * 180f, 0f);

                }
            }
            mech.launch = false;


            
        

        }
    }


    void trailRenderer()
    {
        trail.emitting = !trail.emitting;
    }

    void OnDrawGizmos()
    {


        //------------------------------------------
        // Cylinder Gizmo
        Vector3 tp = transform.position;

        Vector3 capsule_end = new Vector3(tp.x, tp.y, -tp.z - 330);

        DrawCylinder(transform.position, capsule_end, Color.green);

    }
    public static void DrawCylinder(Vector3 start, Vector3 end, Color color, float radius = 1.0f)
    {
        Vector3 up = (end - start).normalized * radius;
        Vector3 forward = Vector3.Slerp(up, -up, 0.5f);
        Vector3 right = Vector3.Cross(up, forward).normalized * radius;

        //Radial circles
        DebugExtension.DrawCircle(start, up, color, radius);
        DebugExtension.DrawCircle(end, -up, color, radius);
        DebugExtension.DrawCircle((start + end) * 0.5f, up, color, radius);

        Color oldColor = Gizmos.color;
        Gizmos.color = color;

        //Side lines
        Gizmos.DrawLine(start + right, end + right);
        Gizmos.DrawLine(start - right, end - right);

        Gizmos.DrawLine(start + forward, end + forward);
        Gizmos.DrawLine(start - forward, end - forward);

        //Start endcap
        Gizmos.DrawLine(start - right, start + right);
        Gizmos.DrawLine(start - forward, start + forward);

        //End endcap
        Gizmos.DrawLine(end - right, end + right);
        Gizmos.DrawLine(end - forward, end + forward);

        Gizmos.color = oldColor;
    }
}
