using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_car_script : MonoBehaviour
{
    public GameObject[] wheels;

    public float speed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

        foreach (GameObject theWheel in wheels)
        {
            theWheel.transform.Rotate(10f, 0, 0);
        }
    }
}
