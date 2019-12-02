using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene_01 : MonoBehaviour {

    public GameObject Teacher;
    public GameObject AJ;

    Animator teacher_anim;
    Animator aj_anim;

    public GameObject[] Dialogues;
    public GameObject GPA_Canvas;
    public GameObject admition_done_panel;
    public GameObject touch_skip_btn;

    public GameObject SSC_GPA_input;
    public GameObject HSC_GPA_input;
    public GameObject SubPanel;

    public int x;

	void Start ()
    {
        teacher_anim = Teacher.GetComponent<Animator>();
        aj_anim = AJ.GetComponent<Animator>();

        teacher_anim.SetInteger("dialogue_is", x % 2);
        aj_anim.SetInteger("dialogue_is", x % 2);

        admition_done_panel.active = false;
        GPA_Canvas.active = false;
        touch_skip_btn.active = true;

        for (int i = 1; i<Dialogues.Length; i++)
        {
            Dialogues[i].active = false;
        }
    }

    public void Change_Cutscene()
    {
        teacher_anim.SetInteger("dialogue_is", x % 2);
        aj_anim.SetInteger("dialogue_is", x % 2);

        if (x >= 6)
        {
            Teacher.active = false;
            AJ.active = false;

            Dialogues[6].active = false;
            touch_skip_btn.active = false;
            GPA_Canvas.active = true;
            return;
        }
        Dialogues[x].active = false;
        Dialogues[x+1].active = true;
        x++;
    }

    public void Submit()
    {
        SubPanel.active = true;

        float SSC_GPA = float.Parse(SSC_GPA_input.GetComponent<Text>().text);
        float HSC_GPA = float.Parse(HSC_GPA_input.GetComponent<Text>().text);
        //int SSC_GPA;
        //int.TryParse(SSC_GPA_input.GetComponent<Text>().text, out SSC_GPA);
        //int HSC_GPA;
        //int.TryParse(SSC_GPA_input.GetComponent<Text>().text, out HSC_GPA);

        float Total_GPA = SSC_GPA + HSC_GPA;

        print(SSC_GPA_input.GetComponent<Text>().text);
        print(HSC_GPA_input.GetComponent<Text>().text);

        if (Total_GPA >= 7 && Total_GPA <= 10)
        {
            string Massege = "Your result is : " + Total_GPA.ToString() + "\n" +
                             "Welcome! You are now allowed for direct admission in Green University and you willget 60% scholarship" +
                             "After deduction of 60% scholarship your total tuition fees will be 2,32,360 BDT but you have to pay 2100 BDT." +
                             "to confirm your admission." +
                             "\nDo you want to admit?";
            SubPanel.transform.Find("Text").GetComponent<Text>().text = Massege;
        }
        else if(Total_GPA < 7)
        {
            string Massege = "Your result is : " + Total_GPA.ToString() + "\n" +
                             "Sorry! Your result is below 7.00. You need to give admission test but you will get 10% scholarship." +
                             "After deduction of 10% scholarship your total tuition fees will be 4,24,560 BDT but you have to pay 2100 BDT to confirm your admission." +
                             "\nDo you want to admit?";
            SubPanel.transform.Find("Text").GetComponent<Text>().text = Massege;
        }

    }
    public void Admission_Done()
    {
        admition_done_panel.active = true;
    }
    public void Next_Level(string scene_name)
    {
        Application.LoadLevel(scene_name);
    }
}
