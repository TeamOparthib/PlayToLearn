using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Select : MonoBehaviour
{
    public int which_level_to_load;

    int unlocked_level;

    void Start()
    {
        unlocked_level = PlayerPrefs.GetInt("level_reached", 1);
    }

    void Update()
    {
        if(unlocked_level < which_level_to_load)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }


        //Delete Save
        if(Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.DeleteAll();
        }
    }

    public void Load_Level()
    {
        Application.LoadLevel(which_level_to_load);
    }
}
