using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static int Coins;
    public int Level;

    public bool hide_coin;

    public GameObject[] indicator;
    public GameObject ScoreDisplayText;

    bool isPaused;
    public GameObject paused_panel;

    private void Start()
    {
        hide_coin = false;
        
    }

    private void Update()
    {
        if (ScoreDisplayText)
        {
            ScoreDisplayText.GetComponent<Text>().text = Coins.ToString();
        }

        Manage_Indicators();

        if (hide_coin)
        {
            GameObject[] coins_obj = GameObject.FindGameObjectsWithTag("coins_tag");
            foreach (GameObject all_coins in coins_obj)
            {
                all_coins.active = false;
            }
        }
        Level = PlayerPrefs.GetInt("lVl");
        Debug.LogError(Level);
    }

    public void Reset_Level()
    {
        switch (Level)
        {
            case 0:
                Coins = 0;
                Application.LoadLevel("Outside");
                break;
            case 1:
                Coins = 250;
                Application.LoadLevel("Outside");
                break;
            case 2:
                Coins = 500;
                Application.LoadLevel("Outside");
                break;
            case 3:
                Coins = 750;
                Application.LoadLevel("Outside");
                break;
            case 4:
                Coins = 1000;
                Application.LoadLevel("Outside");
                break;
            case 5:
                Coins = 1250;
                Application.LoadLevel("Outside");
                break;
            case 6:
                Coins = 1500;
                Application.LoadLevel("Outside");
                break;
            case 7:
                Coins = 1750;
                Application.LoadLevel("Outside");
                break;
        }
    }

    void Manage_Indicators()
    {
        // 0 => b1
        // 1 => talk admission
        // 2 => 302 orientaton
        // 3 => b2
        // 4 => id card
        // 5 => registration
        // 6 => class
        // 7 => Exam
        // 8 => certificate

        switch (Coins)
        {
            case 200:                       //                  enter b1
                if (indicator[0] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 0;
                PlayerPrefs.SetInt("lVl", 0);
                indicator[0].active = true;
                indicator[3].active = false;
                break;
            case 250:                       //cutscene01        admission
                if (indicator[1] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 1;
                PlayerPrefs.SetInt("lVl", 1);
                indicator[1].active = true;
                indicator[2].active = false;
                indicator[4].active = false;
                indicator[8].active = false;
                break;
            case 450:                       //                  b2 orientation
                if (indicator[0] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 1;
                PlayerPrefs.SetInt("lVl", 1);
                indicator[0].active = true;
                indicator[3].active = false;
                break;
            case 500:                       //cutscene02        302 for orientation
                if (indicator[2] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 2;
                PlayerPrefs.SetInt("lVl", 2);
                indicator[2].active = true;
                indicator[1].active = false;
                indicator[4].active = false;
                indicator[8].active = false;
                break;
            case 700:                       //                  enter b1 for id
                if (indicator[0] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 2;
                PlayerPrefs.SetInt("lVl", 2);
                indicator[0].active = true;
                indicator[3].active = false;
                break;
            case 750:                       //cutscene03        talk for id
                if (indicator[4] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 3;
                PlayerPrefs.SetInt("lVl", 3);
                indicator[4].active = true;
                indicator[1].active = false;
                indicator[2].active = false;
                indicator[8].active = false;
                break;
            case 950:                       //                  enter b2
                if (indicator[3] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 3;
                PlayerPrefs.SetInt("lVl", 3);
                indicator[3].active = true;
                indicator[0].active = false;
                break;
            case 1000:                       //cutscene04        talk registration
                if (indicator[5] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 4;
                PlayerPrefs.SetInt("lVl", 4);
                indicator[5].active = true;
                indicator[6].active = false;
                indicator[7].active = false;
                break;
            case 1200:                       //                  enter b2
                if (indicator[3] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 4;
                PlayerPrefs.SetInt("lVl", 4);
                indicator[3].active = true;
                indicator[0].active = false;
                break;
            case 1250:                      //cutscene05        class
                if (indicator[6] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 5;
                PlayerPrefs.SetInt("lVl", 5);
                indicator[6].active = true;
                indicator[5].active = false;
                indicator[7].active = false;
                break;
            case 1450:
                if (indicator[3] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 5;
                PlayerPrefs.SetInt("lVl", 5);
                indicator[3].active = true;
                indicator[0].active = false;
                break;
            case 1500:
                if (indicator[7] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 6;
                PlayerPrefs.SetInt("lVl", 6);
                indicator[7].active = true;
                indicator[5].active = false;
                indicator[6].active = false;
                break;
            case 1700:
                if (indicator[0] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 6;
                PlayerPrefs.SetInt("lVl", 6);
                indicator[0].active = true;
                indicator[3].active = false;
                break;
            case 1750:
                if (indicator[8] != null)
                {
                    if (!hide_coin) hide_coin = true;
                }
                //Level = 7;
                PlayerPrefs.SetInt("lVl", 7);
                indicator[8].active = true;
                indicator[1].active = false;
                indicator[2].active = false;
                indicator[4].active = false;
                break;
        }
    }
    

    public void Load_Scene(string scene_name)
    {
        Application.LoadLevel(scene_name);
    }

    public void Pause()
    {
        if (!isPaused)
        {
            paused_panel.active = true;
            Time.timeScale = 0;
            isPaused = true;
        }
    }
    public void Resume()
    {
        if (isPaused)
        {
            paused_panel.active = false;
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}
