
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThridPersonInput : MonoBehaviour
{

    public FixedJoystick LeftJoystick;
    public FixedButton Button;
    public FixedTouchField TouchField;
    protected ThirdPersonUserControl Control;

    public float CameraAngle=180;
    public float Camera_Angle_Speed = 0.8f;

    public Vector3 cam_pos = new Vector3(0, 2, 3);

    // Use this for initialization
    void Start()
    {
        Control = GetComponent<ThirdPersonUserControl>();

    }

    // Update is called once per frame
    void Update()
    {
        Control.m_Jump = Button.Pressed;
        Control.Hinput = LeftJoystick.inputVector.x;
        Control.Vinput = LeftJoystick.inputVector.y;

        CameraAngle += TouchField.TouchDist.x * Camera_Angle_Speed;

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * cam_pos;
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2.2f - Camera.main.transform.position, Vector3.up);

    }
}