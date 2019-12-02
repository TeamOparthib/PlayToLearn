using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exam_Script : MonoBehaviour
{
    public int marks;
    public GameObject[] Questions;
    public int i;
    public GameObject Congratulations_Text;
    public GameObject Sorry_Text;

    public int pass_mark = 30;

    private void Update()
    {
        if(i >= 5)
        {
            string Message_01 = "Your result is " + marks + " out of 50.";
            GameObject.Find("Result_Text").GetComponent<Text>().text = Message_01;
            if(marks >= pass_mark)
            {
                if (PlayerPrefs.GetInt("level_reached") <= SceneManager.GetActiveScene().buildIndex)
                {
                    PlayerPrefs.SetInt("level_reached", SceneManager.GetActiveScene().buildIndex + 1);
                }
                Congratulations_Text.active = true;
                Sorry_Text.active = false;
            }
            else
            {
                Sorry_Text.active = true;
                Congratulations_Text.active = false;
            }
        }
    }

    public void Right_Answer()
    {
        Questions[i + 1].active = true;
        Questions[i].active = false;
        i++;
        marks += 10;
    }
    public void Wrong_Answer()
    {
        Questions[i + 1].active = true;
        Questions[i].active = false;
        i++;
    }
    public void Next_Level()
    {
        Application.LoadLevel("Levels");
    }
    public void Retake()
    {
        Application.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
