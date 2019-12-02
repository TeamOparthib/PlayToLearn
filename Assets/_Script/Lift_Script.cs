using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift_Script : MonoBehaviour
{
    Animator anim;
    public GameObject Lift_Mesh;

    public GameObject lift_butn_Canvas;

    public Transform ground_floor_towards;
    public Transform fourth_floor_towards;
    public Transform eighth_floor_towards;

    public static int floor_no = 1;

    public float lift_speed;
    bool flag = true;

    void Start()
    {
        anim = Lift_Mesh.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (floor_no == 4)
        {
            transform.position = Vector3.MoveTowards(transform.position, fourth_floor_towards.position, lift_speed * Time.deltaTime);
            if(transform.position == fourth_floor_towards.position && !flag)
            {
                flag = true;
                anim.SetBool("Open_Door", true);
            }
        }
        else if (floor_no == 8)
        {
            transform.position = Vector3.MoveTowards(transform.position, eighth_floor_towards.position, lift_speed * Time.deltaTime);
            if (transform.position == eighth_floor_towards.position && !flag)
            {
                flag = true;
                anim.SetBool("Open_Door", true);
            }
        }
        else if (floor_no == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, ground_floor_towards.position, lift_speed * Time.deltaTime);
            if (transform.position == ground_floor_towards.position && !flag)
            {
                flag = true;
                anim.SetBool("Open_Door", true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (GetComponent<Collider>().GetType() == typeof(BoxCollider))
        {
            if (other.tag == "Player")
            {
                anim.SetBool("Open_Door", true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (GetComponent<Collider>().GetType() == typeof(BoxCollider))
        {
            if (other.tag == "Player")
            {
                anim.SetBool("Open_Door", false);
            }
        }
    }

    public void Fourth_Floor()
    {
        anim.SetBool("Open_Door", false);
        flag = false;
        lift_butn_Canvas.active = false;
        floor_no = 4;
    }
    public void Eight_Floor()
    {
        anim.SetBool("Open_Door", false);
        flag = false;
        lift_butn_Canvas.active = false;
        floor_no = 8;
    }
    public void Ground_Floor()
    {
        anim.SetBool("Open_Door", false);
        flag = false;
        lift_butn_Canvas.active = false;
        floor_no = 1;
    }

}
