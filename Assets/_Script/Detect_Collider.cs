using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_Collider : MonoBehaviour
{
    public string scene_name;

    public Vector3 GizmosSize;
    public Vector3 GizmosPos;

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            GameObject.FindObjectOfType<GameManagerScript>().GetComponent<GameManagerScript>().Load_Scene(scene_name);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + GizmosPos, GizmosSize);
    }
}
