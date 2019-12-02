using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class player_script : MonoBehaviour
{
    public GameObject Gameover_panel;
    public GameObject win_panel;
    public GameObject pause_panel;

    public bool isPaused;

    public GameObject coin_particle;
    AudioClip coin_sound;
    AudioClip gameover_sound;

    int score;

    int needed_score = 10;



    public GameObject Instruction;

    GameObject[] ans_cubes;
    GameObject ques_cube;
    public int clue_collected = 0;

    int number_of_green_box;

    //******************************For Car*****************************************************/

    public bool isCar;

    public GameObject[] wheels;
    public float wheelSpeed;

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;

    public bool auto_drive = false;
    public float auto_side_translation;

    float translation = 0;
    float rotation;


    void Start()
    {
        ques_cube = GameObject.Find("Ques Cube");
        ques_cube.active = false;

        ans_cubes = GameObject.FindGameObjectsWithTag("ans_cube");
        number_of_green_box = ans_cubes.Length;
        foreach (GameObject theAns in ans_cubes)
                                                theAns.active = false;

        needed_score = GameObject.FindGameObjectsWithTag("coins_tag").Length;

        coin_sound = Resources.Load<AudioClip>("power_UP_02");
        gameover_sound = Resources.Load<AudioClip>("76376__deleted-user-877451__game-over");
    }

    void Update()
    {
        GameObject.Find("Score").GetComponent<Text>().text = score.ToString() + "/" + needed_score;

        if(score >= needed_score)
        {
            foreach (GameObject theAns in ans_cubes)
                                                    theAns.active = true;

            if(number_of_green_box > 1)
            {
                Instruction.GetComponent<Text>().text = "Find " + number_of_green_box + " green boxes.";
            }
            else
            {
                Instruction.GetComponent<Text>().text = "Find a green box.";
            }
            Instruction.GetComponent<Text>().color = Color.green;
            Instruction.GetComponent<Animator>().SetTrigger("showInstruction");
        }

        if(clue_collected >= ans_cubes.Length)
        {
            ques_cube.active = true;
            Instruction.GetComponent<Text>().text = "Find the yellow question box.";
            Instruction.GetComponent<Text>().color = Color.yellow;
            Instruction.GetComponent<Animator>().SetTrigger("showInstruction");
        }






        if(isCar)
        {
            if (auto_drive)
            {
                transform.Translate(-speed * 0.5f * Time.deltaTime, 0, 0);

                transform.Translate(0, 0, rotation * auto_side_translation);

                //rotation *= 0.5f;

                foreach (GameObject theWheel in wheels)
                {
                    theWheel.transform.Rotate(0, 0, wheelSpeed);
                }
            }
            else
            {
                translation = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * speed;

                transform.Translate(-translation, 0, 0);

                if (translation > 0)
                {
                    foreach (GameObject theWheel in wheels)
                    {
                        theWheel.transform.Rotate(0, 0, wheelSpeed);
                    }
                }
                else if (translation < 0)
                {
                    foreach (GameObject theWheel in wheels)
                    {
                        theWheel.transform.Rotate(0, 0, -wheelSpeed);
                    }
                }
            }

            rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

            transform.Rotate(0, rotation, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "win":

                Instruction.active = false;
                win_panel.active = true;

                if (PlayerPrefs.GetInt("level_reached") <= SceneManager.GetActiveScene().buildIndex)
                {
                    PlayerPrefs.SetInt("level_reached", SceneManager.GetActiveScene().buildIndex + 1);
                }
                break;

            case "coins_tag":
                AudioSource.PlayClipAtPoint(coin_sound, other.transform.position);
                score++;
                Instantiate(coin_particle, other.transform.position, Random.rotation);
                Destroy(other.gameObject);
                break;


            case "spike":
                GameOver();
                break;
            case "car":
                GameOver();
                break;
            case "blade":
                GameOver();
                break;
            case "red_coin":
                GameOver();
                break;

        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        Gameover_panel.active = true;
        AudioSource.PlayClipAtPoint(gameover_sound, Camera.main.transform.position);
    }

    public void Retry()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Go_to_Level_select()
    {
        Application.LoadLevel("Levels");
    }

    public void Pause()
    {
        if (!isPaused)
        {
            pause_panel.active = true;
            Time.timeScale = 0;
            isPaused = true;
        }
    }
    public void Resume()
    {
        if (isPaused)
        {
            pause_panel.active = false;
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}
