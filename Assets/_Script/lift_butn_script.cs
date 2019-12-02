using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift_butn_script : MonoBehaviour {

    public GameObject lift_butn_Canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lift_butn_Canvas.active = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            lift_butn_Canvas.active = false;
        }
    }
}
