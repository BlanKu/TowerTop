using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapScipt : MonoBehaviour
{
    private SceneVariables scenevariables;

    private void Start()
    {
        scenevariables = GameObject.Find("SceneVariables").GetComponent<SceneVariables>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Player")
        {
            scenevariables.GameOver();
        }
    }
}
