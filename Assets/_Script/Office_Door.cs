using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Office_Door : MonoBehaviour
{
    Animator anim;
    public GameObject Door_Mesh;
    
    void Start()
    {
        anim = Door_Mesh.GetComponent<Animator>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Open_Door", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Open_Door", false);
        }
    }
}
