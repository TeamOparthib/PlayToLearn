using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuesAns : MonoBehaviour
{
    public bool isAns;

    public GameObject Panel;

    public GameObject[] Questions;

    public GameObject Failed_Panel;

    public GameObject particle;

    public int i;

    bool isClueCollected;

    void Start()
    {
        Panel.active = false;
        if (!isAns) Failed_Panel.active = false;
    }

    void Update()
    {
        if(i >= Questions.Length - 1 && !isAns)
        {
            Instantiate(particle, transform.position, Random.rotation);
            GameObject.Find("Gate").GetComponent<Animator>().SetBool("openGate", true);
            Destroy(gameObject);
        }
    }

    public void Right_Answer()
    {
        Questions[i + 1].active = true;
        Questions[i].active = false;
        i++;
    }
    public void Wrong_Answer()
    {
        Questions[i].active = false;
        i = 0;
        Questions[i].active = true;
        Failed_Panel.active = true;
    }

    public void NextButn()
    {
        if(!isAns) Failed_Panel.active = false;

        Panel.active = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(!isAns)
            {
                Instantiate(particle, transform.position, Random.rotation);
            }

            if(isAns && !isClueCollected)
            {
                FindObjectOfType<player_script>().clue_collected++;
                isClueCollected = true;
            }

            Panel.active = true;
        }
    }
}
