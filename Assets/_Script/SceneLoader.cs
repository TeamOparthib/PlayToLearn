using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public InputField name;
    public Text fText;

    public void getset()
    {
        fText.text = "Hello, " + name.text;
    }

    public void doquit()
    {
        Application.Quit();
    }
    public void LoadScene(string scene_name)
    {
        Application.LoadLevel(scene_name);
    }
}
