using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_07 : MonoBehaviour
{
    public int x;
    public GameObject[] Dialogues;

    public GameObject AJ;

    Animator aj_anim;

    void Start()
    {
        aj_anim = AJ.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void change_cutscene_07()
    {
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
