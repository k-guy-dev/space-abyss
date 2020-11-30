using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float cameraHeight = 20.0f;

    void Update()
    {
        Vector3 pos = player.transform.position;
        float objectZ = pos.z;
        float cameraZ = transform.position.z;
        transform.LookAt(player.transform,-Vector3.up);
        if(objectZ - cameraZ > 2f)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y, pos.z);

        }
    }
    
}