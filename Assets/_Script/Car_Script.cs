using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Script : MonoBehaviour
{
    public float speed;

    Vector3 start_pos;
    float end_pos;

    public bool isRevert;

    void Start()
    {
        if (!isRevert)
        {
            start_pos = new Vector3(-700, 0, -3);
            end_pos = 700;
        }
        else
        {
            start_pos = new Vector3(700, 0, -12.5f);
            end_pos = -700;
        }
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        if (transform.position.x >= end_pos && !isRevert)
        {
            transform.position = start_pos;
        }
        else if(transform.position.x <= end_pos && isRevert)
        {
            transform.position = start_pos;
        }
    }
}
