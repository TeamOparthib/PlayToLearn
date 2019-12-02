using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cutscene_05 : MonoBehaviour
{
    int countDownStartValue = 20;
    public String LevelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer();
    }

    void countDownTimer()
    {
        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);

            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            Application.LoadLevel(LevelToLoad);

        }

    }
}
