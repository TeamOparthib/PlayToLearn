using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Distance_Ctrl : MonoBehaviour
{
    public float cam_distance_speed = 0.5f;

    bool go_forward;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (go_forward)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<ThridPersonInput>().cam_pos.z >= 1.6)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<ThridPersonInput>().cam_pos.z -= cam_distance_speed;
            }
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<ThridPersonInput>().cam_pos.z <= 3)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<ThridPersonInput>().cam_pos.z += cam_distance_speed;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "wall_tag")
        {
            go_forward = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "wall_tag")
        {
            go_forward = false;
        }
    }
}
