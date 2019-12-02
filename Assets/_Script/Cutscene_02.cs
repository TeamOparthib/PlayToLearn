using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_02 : MonoBehaviour {

    public int x;
    public GameObject[] Dialogues;

    public GameObject Teacher;
    public GameObject AJ;

    Animator teacher_anim;
    Animator aj_anim;

    public GameObject Level_Complete_Canvas;


    void Start ()
    {
        Level_Complete_Canvas.active = false;
        teacher_anim = Teacher.GetComponent<Animator>();
        aj_anim = AJ.GetComponent<Animator>();
	}
	
	void Update ()
    {
		
	}

    public void change_cutscene_02()
    {
        if (x >= 5)
        {
            Level_Complete_Canvas.active = true;
            return;
        }
        teacher_anim.SetInteger("teacher_talk", x);
        aj_anim.SetInteger("aj_talk", x);

        Dialogues[x].active = false;
        Dialogues[x + 1].active = true;
        x++;
    }

    public void Next_Level(string scene_name)
    {
        Application.LoadLevel(scene_name);
    }
}
